using StackExchange.Redis;

namespace Ipr.Caching.Redis;

internal class RedisConsumerGroup<T> where T : class
{
    private readonly IDatabase _redisDb;

    public RedisConsumerGroup(IConnectionMultiplexer redisConnection)
    {
        _redisDb = redisConnection.GetDatabase();
    }

    public async Task CreateConsumerGroupAsync(string streamName, string groupName)
    {

        var stremGroups = await _redisDb.StreamGroupInfoAsync(streamName);
        
        var isExistedConsumerGroup = stremGroups.Any(x => x.Name == groupName);

        if (!isExistedConsumerGroup)
        {
            await _redisDb.StreamCreateConsumerGroupAsync(streamName, groupName, "1712234711751", true);
        }
    }

    public async Task<StreamEntry[]> Read(string streamName, string groupName, string consumer)
    {

        var c = await _redisDb.StreamReadGroupAsync(streamName, groupName, consumer, count:5);

        return c;
    }
}
