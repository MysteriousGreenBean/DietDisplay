using Castle.DynamicProxy;

namespace DietDisplay.API.Logic.Cache
{
    public interface ICache
    {
        /// <summary>
        /// Caches method invocation result until the end of calendar day.
        /// </summary>
        /// <param name="cacheKey">Key under which to cache the result.</param>
        /// <param name="invocation">Invocation of method which result should be cached.</param>
        void CacheMethodInvocationPerCalendarDay(string cacheKey, IInvocation invocation);
        /// <summary>
        /// Gets cached value if it exists and is still valid.
        /// </summary>
        /// <param name="cacheKey">Cache key of value to obtain.</param>
        /// <returns>Cached object if any is cached, null otherwise.</returns>
        object? GetPerCalendarDeyCacheValue(string cacheKey);
    }
}
