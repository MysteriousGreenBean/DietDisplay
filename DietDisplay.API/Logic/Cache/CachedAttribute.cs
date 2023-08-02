namespace DietDisplay.API.Logic.Cache
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class CachedAttribute : Attribute
    {
        /// <summary>
        /// Duration of cache of method invocation.
        /// </summary>
        public CacheDuration CacheDuration { get; init; }

        /// <summary>
        /// Scope of cache of method invocation.
        /// </summary>
        public CacheScope CacheScope { get; init; }

        /// <summary>
        /// Marks method as cached.
        /// </summary>
        /// <param name="cacheDuration">Duration of cache.</param>
        /// <param name="cacheScope">Scope of cache.</param>
        public CachedAttribute(CacheDuration cacheDuration, CacheScope cacheScope = CacheScope.None)
        {
            CacheDuration = cacheDuration;
            CacheScope = cacheScope;
        }
    }

    public enum CacheDuration
    {
        /// <summary>
        /// Method result will be cached until the end of calendar day.
        /// </summary>
        PerCalendarDay,
    }

    public enum CacheScope
    {
        /// <summary>
        /// First call to the method will cache the result for all subsequent calls.
        /// </summary>
        None,
        /// <summary>
        /// First call to the method with given arguments will cache the result for all subsequent calls with the same arguments.
        /// It is possible to cache multiple results for different arguments.
        /// Argument values are compared by their string representation.
        /// </summary>
        PerArguments
    }
}
