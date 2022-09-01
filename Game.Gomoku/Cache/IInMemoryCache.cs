namespace Game.Gomoku.Cache
{
    public interface IInMemoryCache
    {
        bool IsCacheExist(string cacheKey);
        T OnGet<T>(string cacheKey) where T : class;
        void OnRemoveCache(string cacheKey);
        void OnSet<T>(string cacheKey, T item) where T : class;
        void OnUpdate<T>(string cacheKey, T item) where T : class;
    }
}