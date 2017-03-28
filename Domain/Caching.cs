using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class Caching
    {
        private static int DurationInMinutes = 100;
        /// <summary>
        /// A generic method for getting and setting objects to the memory cache.
        /// </summary>
        /// <typeparam name="T">The type of the object to be returned.</typeparam>
        /// <param name="cacheItemName">The name to be used when storing this object in the cache.</param>
        /// <param name="cacheTimeInMinutes">How long to cache this object for.</param>
        /// <param name="objectSettingFunction">A parameterless function to call if the object isn't in the cache and you need to set it.</param>
        /// <returns>An object of the type you asked for</returns>
        public static T Get<T>(string cacheItemName)
        {
            ObjectCache cache = MemoryCache.Default;
            var cachedObject = cache[cacheItemName];
            if (cachedObject != null)
                return (T)cachedObject;
            return default(T);
        }

        public static T Set<T>(string cacheItemName, Func<T> objectSettingFunction)
        {
            ObjectCache cache = MemoryCache.Default;
            var cachedObject = objectSettingFunction();
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(DurationInMinutes);
            cache.Set(cacheItemName, cachedObject, policy);
            return (T)cachedObject;
        }
        public static void Set<T>(string cacheItemName, T obj)
        {
            MemoryCache.Default.Set(cacheItemName, obj, new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(DurationInMinutes) });
        }
        public static void Remove(string cacheItemName)
        {
            ObjectCache cache = MemoryCache.Default;
            if (cache.Contains(cacheItemName))
            {
                cache.Remove(cacheItemName);
            }
        }

        public static bool Contains(string key)
        {
            ObjectCache cache = MemoryCache.Default;
            return cache.Contains(key);
        }
    }
}
