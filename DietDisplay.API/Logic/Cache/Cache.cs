using Castle.DynamicProxy;

namespace DietDisplay.API.Logic.Cache
{
    public class Cache : ICache
    {
        private readonly Dictionary<string, CacheEntry<object, DateTime>> perCalendarDayCache = new Dictionary<string, CacheEntry<object, DateTime>>();

        /// <inheritdoc/>
        public void CacheMethodInvocationPerCalendarDay(string cacheKey, IInvocation invocation)
        {
            invocation.Proceed();
            var cacheEntry = new CacheEntry<object, DateTime>(invocation.ReturnValue, DateTime.UtcNow.Date, (createdDate) => createdDate == DateTime.UtcNow.Date);
            SetPerCalendarDayCacheValue(cacheKey, cacheEntry);
        }


        /// <inheritdoc/>
        public object? GetPerCalendarDeyCacheValue(string cacheKey)
        {
            if (perCalendarDayCache.TryGetValue(cacheKey, out CacheEntry<object, DateTime>? cacheValue))
                return cacheValue.IsCacheValid ? cacheValue.CachedObject : null;
            else
                return null;
        }

        private void SetPerCalendarDayCacheValue(string cacheKey, CacheEntry<object, DateTime> value)
            => perCalendarDayCache[cacheKey] = value;
    }
}
