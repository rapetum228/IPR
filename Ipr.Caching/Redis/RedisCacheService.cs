using StackExchange.Redis;
using System.Text.Json;

namespace Ipr.Caching.Redis;

internal class RedisCacheService<T> where T : class
{
    private readonly IDatabase _redisDb;

    public RedisCacheService(IConnectionMultiplexer redisConnection)
    {
        _redisDb = redisConnection.GetDatabase();
    }


    public async Task<EntityContainerCached<T>?> GetCachedEntityByKeyAsync(string key, bool mustActual = false)
    {
        var cachedSerialized = await _redisDb.StringGetAsync(key);

        if (!string.IsNullOrWhiteSpace(cachedSerialized))
        {
            return JsonSerializer.Deserialize<EntityContainerCached<T>>(cachedSerialized);
        }

        return null;
    }

    public async IAsyncEnumerable<EntityContainerCached<T>?> GetAllContaineredEntitiesByPartialKey(string partialKey)
    {
        IEnumerable<string> keys = _redisDb.GetAllKeys($"{partialKey}");

        foreach (string key in keys)
        {
            yield return await GetCachedEntityByKeyAsync(key);
        }
    }

    public async Task DeleteCachedEntityAsync(string key)
    {
        await _redisDb.KeyDeleteAsync(key);
    }

    public async Task DeleteCachedEntityByKeyAsync(string key)
    {
        await _redisDb.KeyDeleteAsync(key);
    }

    private static EntityContainerCached<T> ConvertToCachedEntity(T originalMessage)
    {
        return new EntityContainerCached<T>()
        {
            Entity = originalMessage,
            LastUpdatedAtUtc = DateTimeOffset.UtcNow
        };
    }

    public async Task AddOrUpdateEntityAsync(T value, string key, TimeSpan? expiry=null)
    {
        var updatedTrackMessageCachedSerialized = JsonSerializer.Serialize(ConvertToCachedEntity(value));

        await _redisDb.StringSetAsync(key, updatedTrackMessageCachedSerialized, expiry);
    }
}
