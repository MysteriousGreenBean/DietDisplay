namespace DietDisplay.API.Logic.Cache
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class CachedAttribute : Attribute
    {
        public CacheScope CacheScope { get; init; }

        public CachedAttribute(CacheScope cacheScope)
        {
            CacheScope = cacheScope;
        }
    }

    public enum CacheScope
    {
        PerCalendarDay
    }
}
