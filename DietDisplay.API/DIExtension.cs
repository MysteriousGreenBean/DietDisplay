using DietDisplay.API.Logic;
using DietDisplay.API.Logic.Database;

namespace DietDisplay.API
{
    public static class DIExtension
    {
        public static void AddDietDisplay(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDatabaseConnection>(sp => new DatabaseConnection(configuration.GetConnectionString("DefaultConnection") 
                ?? throw new InvalidDataException("Connection string not defined in the file")));
            services.AddTransient<IMealSelector, MealSelector>();
        }
    }
}
