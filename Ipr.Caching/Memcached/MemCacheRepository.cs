using Enyim.Caching;

namespace Ipr.Caching.Memcached;

internal class MemCacheRepository 
{
    private readonly IMemcachedClient _memcachedClient;

    public MemCacheRepository(IMemcachedClient memcachedClient)
    {
        _memcachedClient = memcachedClient;
    }

    public void Set<T>(string key, T value, int seconds = 100)
    {
        _memcachedClient.Set(key, value, seconds);
    }

    public T GetCache<T>(string key)
    {
        return _memcachedClient.Get<T>(key);
    }
}