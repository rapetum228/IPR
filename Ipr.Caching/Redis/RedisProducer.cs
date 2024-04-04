using StackExchange.Redis;
using System.Reflection;

namespace Ipr.Caching.Redis;

internal class RedisProducer<T> where T : class
{
    private readonly IDatabase _redisDb;

    public RedisProducer(IConnectionMultiplexer redisConnection)
    {
        _redisDb = redisConnection.GetDatabase();
    }

    public async Task AddToStreamAsync(string key, T value)
    {
        var properties = value.GetType().GetProperties(bindingAttr: BindingFlags.Public | BindingFlags.Instance);

        NameValueEntry[] nameValueEntries = new NameValueEntry[properties.Length];

        for (int i = 0; i< nameValueEntries.Length; i++)
            nameValueEntries[i] = new NameValueEntry(properties[i].Name, properties[i].GetValue(value).ToString());

        await _redisDb.StreamAddAsync(key, nameValueEntries);
    }
}