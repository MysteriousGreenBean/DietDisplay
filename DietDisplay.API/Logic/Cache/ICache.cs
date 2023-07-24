using Castle.DynamicProxy;

namespace DietDisplay.API.Logic.Cache
{
    public interface ICache
    {
        void CacheMethodInvocationPerCalendarDay(string cacheKey, IInvocation invocation);
        object? GetPerCalendarDeyCacheValue(string cacheKey);
    }
}
