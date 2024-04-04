using StackExchange.Redis;

namespace Ipr.Caching.Redis;

/*
 reids list

 redis streams
 */
public static class RedisConnector
{
    public static ConnectionMultiplexer GetConnection()
    {
        ConfigurationOptions configurationOptions = new()
        {
            EndPoints = { "localhost:6379" },
            Password = "my-password",
            AbortOnConnectFail = false
        };

        ConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect(configurationOptions);

        return multiplexer;
    }

    public static IEnumerable<string> GetAllKeys(this IDatabase database, string keyPattern)
    {
        IServer server = database.Multiplexer.GetServer(database.IdentifyEndpoint()!);
        IEnumerable<RedisKey> keys = server.Keys(database.Database, $"{keyPattern}:*");

        return keys.Select(k => k.ToString());
    }
}
