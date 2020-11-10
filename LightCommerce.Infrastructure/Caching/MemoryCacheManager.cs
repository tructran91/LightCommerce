using LightCommerce.Application.Common.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace LightCommerce.Infrastructure.Caching
{
    public class MemoryCacheManager : IMemoryCacheManager
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public TItem Set<TItem>(string key, TItem value)
        {
            var cacheExpiryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddYears(1),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromMinutes(2)
            };

            return _memoryCache.Set(key, value, cacheExpiryOptions);
        }

        public bool TryGetValue<TItem>(string key, out TItem value)
        {
            var isCache = _memoryCache.TryGetValue(key, out TItem valueCache);

            value = valueCache;

            return isCache;
        }
    }
}
