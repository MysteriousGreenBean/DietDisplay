namespace DietDisplay.API.Logic.Cache
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class CachedAttribute : Attribute
    {
        /// <summary>
        /// Cache scope of method invocation.
        /// </summary>
        public CacheScope CacheScope { get; init; }

        /// <summary>
        /// Marks method as cached.
        /// </summary>
        /// <param name="cacheScope">Scope of cache.</param>
        public CachedAttribute(CacheScope cacheScope)
        {
            CacheScope = cacheScope;
        }
    }

    public enum CacheScope
    {
        /// <summary>
        /// Method result will be cached until the end of calendar day.
        /// </summary>
        PerCalendarDay
    }
}
