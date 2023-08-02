using Castle.DynamicProxy;
using DietDisplay.API.Logic.DateProvider;

namespace DietDisplay.API.Logic.Cache
{
    public class Cache : ICache
    {
        private readonly Dictionary<string, CacheEntry<object, DateTime>> perCalendarDayCache = new Dictionary<string, CacheEntry<object, DateTime>>();
        private readonly IDateProvider dateProvider;

        public Cache(IDateProvider dateProvider)
        {
            this.dateProvider = dateProvider;
        }

        /// <inheritdoc/>
        public void CacheMethodInvocationPerCalendarDay(string cacheKey, IInvocation invocation)
        {
            invocation.Proceed();
            var cacheEntry = new CacheEntry<object, DateTime>(invocation.ReturnValue, dateProvider.GetCurrentUtcDate(), (createdDate) => createdDate == dateProvider.GetCurrentUtcDate());
            SetPerCalendarDayCacheValue(cacheKey, cacheEntry);
        }


        /// <inheritdoc/>
        public object? GetPerCalendarDayCacheValue(string cacheKey)
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
