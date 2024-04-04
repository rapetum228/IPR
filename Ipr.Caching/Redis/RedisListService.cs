using StackExchange.Redis;
using System.Text.Json;

namespace Ipr.Caching.Redis;

internal class RedisListService<T> where T: class
{
    private readonly IDatabase _redisDb;

    public RedisListService(IConnectionMultiplexer redisConnection)
    {
        _redisDb = redisConnection.GetDatabase();
    }

    public async Task ListLeftPush(string key, T value)
    {
        var ser = JsonSerializer.Serialize(value);
        var c = await _redisDb.ListLeftPushAsync(key, ser);
    }

    public async Task<T> ListLeftPop(string key)
    {
        var c = await _redisDb.ListLeftPopAsync(key);

        return JsonSerializer.Deserialize<T>(c);
    }

    public async Task<T> ListRightPop(string key)
    {
        var c = await  _redisDb.ListRightPopAsync(key);

        return JsonSerializer.Deserialize<T>(c);
    }

    public async Task<long> GetLength(string key)
    {
        var c = _redisDb.ListLength(key);

        return c;
    }

    public async Task<string> ListMove(string key1, string key2)
    {
        var c = await  _redisDb.ListMoveAsync(key1, key2, ListSide.Left, ListSide.Right);

        return c;
    }
}
