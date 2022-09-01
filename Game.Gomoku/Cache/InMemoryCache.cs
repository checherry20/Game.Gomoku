using Microsoft.Extensions.Caching.Memory;

namespace Game.Gomoku.Cache
{
    public class InMemoryCache : IInMemoryCache
    {
        private readonly IMemoryCache _memoryCache;

        public InMemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void OnSet<T>(string cacheKey, T item) where T : class
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(2))
                    .SetPriority(CacheItemPriority.Normal);
            _memoryCache.Set(cacheKey, item, cacheEntryOptions);
        }

        public T OnGet<T>(string cacheKey) where T : class
        {
            _memoryCache.TryGetValue(cacheKey, out T item);
            return item;
        }

        public void OnRemoveCache(string cacheKey)
        {
            _memoryCache.Remove(cacheKey);
        }

        public bool IsCacheExist(string cacheKey)
        {
            return _memoryCache.TryGetValue(cacheKey, out _);
        }

        public void OnUpdate<T>(string cacheKey, T item) where T : class
        {
            OnRemoveCache(cacheKey);
            OnSet(cacheKey, item);
        }

    }
}
