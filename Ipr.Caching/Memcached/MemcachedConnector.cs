using Enyim.Caching;
using Enyim.Caching.Configuration;
using Microsoft.Extensions.Logging;

namespace Ipr.Caching.Memcached;

public static class MemcachedConnector
{
    public static IMemcachedClient GetConnection()
    {

        ILoggerFactory loggerFactory = new LoggerFactory();

        IMemcachedClientConfiguration config = new MemcachedClientConfiguration(loggerFactory, new MemcachedClientOptions
        {
            Servers = new () { new Server { Address = "localhost", Port = 11211 } }
        });

        IMemcachedClient client = new MemcachedClient(loggerFactory, config);

        return client;
    }

    public static void Test()
    {

        Console.WriteLine("Set cache");
        var connection = GetConnection();

        var cacheRepository = new MemCacheRepository(connection);
        cacheRepository.Set("aer", "123");

        Console.WriteLine("Sleep for 2 minutes");
        //Thread.Sleep(1000 * 60 * 2);

        Console.WriteLine("Get cache");

        Console.WriteLine($"Value from cache {cacheRepository.GetCache<string>("Key_1")}");
        Console.ReadLine();
    }
}
