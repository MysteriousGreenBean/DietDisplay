using Castle.DynamicProxy;
using System.Reflection;

namespace DietDisplay.API.Logic.Cache
{
    public class CacheInterceptor : IInterceptor
    {
        private readonly ICache cache;

        public CacheInterceptor(ICache cache)
        {
            this.cache = cache;
        }

        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method.IsDefined(typeof(CachedAttribute)))
            {
                var attribute = invocation.Method.GetCustomAttribute<CachedAttribute>() ?? throw new InvalidDataException("Could not read CachedAttribute from method invocation");
                HandleCacheAttribute(attribute, invocation);
            }
            else
                invocation.Proceed();
        }

        private void HandleCacheAttribute(CachedAttribute attribute, IInvocation invocation)
        {
            switch (attribute.CacheScope)
            {
                case CacheScope.PerCalendarDay:
                    HandlePerCalendarDayCacheAttribute(invocation);
                    break;
                default:
                    throw new InvalidDataException($"CacheScope {attribute.CacheScope} not implemented");
            }
        }

        private void HandlePerCalendarDayCacheAttribute(IInvocation invocation)
        {
            var cacheKey = $"{invocation.TargetType.FullName}_{invocation.Method.Name}";

            object? cacheValue = cache.GetPerCalendarDeyCacheValue(cacheKey);

            if (cacheValue == null)
            {
                cache.CacheMethodInvocationPerCalendarDay(cacheKey, invocation);
            }
            else
            {
                invocation.ReturnValue = cacheValue;
            }
        }
    }
}
