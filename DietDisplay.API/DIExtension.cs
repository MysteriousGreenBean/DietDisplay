using Castle.DynamicProxy;
using DietDisplay.API.Logic;
using DietDisplay.API.Logic.Cache;
using DietDisplay.API.Logic.Database;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace DietDisplay.API
{
    public static class DIExtension
    {
        public static void AddDietDisplay(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ICache, Cache>();
            services.AddTransient<CacheInterceptor>();
            services.AddTransient<MealSelector>();
            services.AddTransient<IDbConnection>(_ => new SqlConnection(configuration.GetConnectionString("DefaultConnection") 
                               ?? throw new InvalidDataException("Connection string not defined in the file")));
            services.AddTransient<IDataAccess, DapperDataAccess>();
            services.AddScoped<IDatabaseConnection, DatabaseConnection>();
            services.AddCacheInterceptor();
        }

        private static void AddCacheInterceptor(this IServiceCollection services)
        {
            services.AddTransient<CacheInterceptor>();

            // Iterate through all assemblies (or a specific assembly if you prefer).
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var proxyGenerator = new ProxyGenerator();
            foreach (var assembly in assemblies)
            {
                // Get all types in the assembly that have methods with the CustomAttribute.
                var interfacesWithCustomAttribute = assembly.GetTypes()
                     .Where(type => type.IsInterface &&
                                    type.GetMethods()
                                        .Any(method => method.IsDefined(typeof(CachedAttribute), inherit: true)))
                     .ToList();

                // Register a proxy for each type that has the CustomAttribute.
                foreach (var @interface in interfacesWithCustomAttribute)
                {
                    if (@interface != null)
                    {
                        services.AddTransient(@interface, provider =>
                        {
                            var targetType = GetTargetTypeForInterface(@interface, assembly);
                            var targetInstance = provider.GetRequiredService(targetType);
                            return proxyGenerator.CreateInterfaceProxyWithTarget(@interface, targetInstance, provider.GetRequiredService<CacheInterceptor>());
                        });
                    }

                }
            }
        }

        private static Type GetTargetTypeForInterface(Type interfaceType, Assembly assembly)
        {
            // In this example, we are assuming that there is only one concrete class
            // implementing the interface in the specified assembly.
            var targetType = assembly.GetTypes().FirstOrDefault(type =>
                interfaceType.IsAssignableFrom(type) && !type.IsInterface && interfaceType.Name == $"I{type.Name}");

            return targetType ?? throw new InvalidOperationException($"No concrete type found for interface '{interfaceType.FullName}'.");
        }
    }
}
