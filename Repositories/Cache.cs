using System;
using System.Runtime.Caching;
using System.Security.AccessControl;

namespace Repositories
{
    public class Cache
    {
        private static ObjectCache cache = MemoryCache.Default;

        public static object get(string key)
        {
            return cache.Get(key);
        }

        public static void add(string key, object objectCache, int time)
        {
            CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
            cacheItemPolicy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(time);
            cache.Add(key, objectCache, cacheItemPolicy);
        }

        public static void add(string key, object objectCache)
        {
            cache.Add(key, objectCache, null);
        }

        public static void remove(string key)
        {
            cache.Remove(key);
        }
    }
}
