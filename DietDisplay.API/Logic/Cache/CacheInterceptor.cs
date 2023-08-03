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
            switch (attribute.CacheDuration)
            {
                case CacheDuration.PerCalendarDay:
                    HandlePerCalendarDayCacheAttribute(invocation, attribute.CacheScope == CacheScope.PerArguments);
                    break;
                default:
                    throw new InvalidDataException($"CacheScope {attribute.CacheDuration} not implemented");
            }
        }

        private void HandlePerCalendarDayCacheAttribute(IInvocation invocation, bool cachePerArguments)
        {
            var cacheKey = GenerateCacheKey(invocation, cachePerArguments);

            object? cacheValue = cache.GetPerCalendarDayCacheValue(cacheKey);

            if (cacheValue == null)
            {
                cache.CacheMethodInvocationPerCalendarDay(cacheKey, invocation);
            }
            else
            {
                invocation.ReturnValue = cacheValue;
            }
        }

        private string GenerateCacheKey(IInvocation invocation, bool cachePerArguments)
        {
            var cacheKey = $"{invocation.TargetType.FullName}_{invocation.Method.Name}";

            if (cachePerArguments)
            {
                foreach (var argument in invocation.Arguments)
                {
                    cacheKey += $"_{argument}";
                }
            }

            return cacheKey;
        }
    }
}
