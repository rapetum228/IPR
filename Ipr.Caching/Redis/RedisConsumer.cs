using StackExchange.Redis;

namespace Ipr.Caching.Redis;

internal class RedisConsumer<T> where T : class
{
    private readonly IDatabase _redisDb;

    public RedisConsumer(IConnectionMultiplexer redisConnection)
    {
        _redisDb = redisConnection.GetDatabase();
    }

    public async Task<StreamEntry[]> ReadStreamAsync(string key)
    {
        var p = await _redisDb.StreamInfoAsync(key);
        return await _redisDb.StreamReadAsync(key, "0", count: 1);
    }
}
