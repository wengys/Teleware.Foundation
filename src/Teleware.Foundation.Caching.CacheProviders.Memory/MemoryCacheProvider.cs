using Microsoft.Extensions.Caching.Memory;
using System;

namespace Teleware.Foundation.Caching.CacheProviders
{
    /// <summary>
    /// 基于内存的缓存源
    /// </summary>
    public class MemoryCacheProvider : ICacheProvider
    {
        private IMemoryCache _cache;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cache"></param>
        public MemoryCacheProvider(IMemoryCache cache)
        {
            _cache = cache;
        }

        /// <inheritdoc/>
        public bool Exist(string key)
        {
            return _cache.TryGetValue(key, out object item);
        }

        /// <inheritdoc/>
        public bool TryGet<T>(string key, out T value)
        {
            var exists = _cache.TryGetValue(key, out object item);
            if (exists)
            {
                value = ((MemoryCacheItem<T>)item).Value;
                return true;
            }
            else
            {
                value = default(T);
                return false;
            }
        }

        /// <inheritdoc/>
        public T GetValueOrDefault<T>(string key, Func<T> itemFactory, CachePolicy policy = null)
        {
            var cachedItem = _cache.Get(key) as MemoryCacheItem<T>;
            if (cachedItem == null)
            {
                lock (_cache)
                {
                    cachedItem = _cache.Get(key) as MemoryCacheItem<T>;
                    if (cachedItem == null)
                    {
                        var item = itemFactory();
                        Set<T>(key, item, policy);
                        return item;
                    }
                }
            }
            return cachedItem.Value;
        }

        /// <inheritdoc/>
        public void Set<T>(string key, T item, CachePolicy policy = null)
        {
            var cacheItem = new MemoryCacheItem<T>
            {
                Value = item
            };
            MemoryCacheEntryOptions opt = new MemoryCacheEntryOptions();

            var entry = _cache.CreateEntry(key);
            entry.Value = item;
            if (policy != null)
            {
                opt.AbsoluteExpirationRelativeToNow = policy.AbsoluteExpiration;
                opt.SlidingExpiration = policy.SlidingExpiration;
            }

            _cache.Set(key, cacheItem, opt);
        }

        ///// <inheritdoc/>
        //public string ProviderName
        //{
        //    get { return "Memory"; }
        //}

        /// <inheritdoc/>
        public void RemoveKey(string cacheKey)
        {
            _cache.Remove(cacheKey);
        }

        ///// <inheritdoc/>
        //public void EnsureInited()
        //{
        //}
        private class MemoryCacheItem<T>
        {
            public T Value { get; set; }
        }
    }
}