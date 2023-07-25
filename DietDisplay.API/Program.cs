using DietDisplay.API;
using DietDisplay.API.Exceptions;
using DietDisplay.API.Logic;
using DietDisplay.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy("LocalReact", builder =>
{
    builder.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
}));
builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true);
builder.Services.AddDietDisplay(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("LocalReact");
}

app.UseHttpsRedirection();

if (app.Environment.IsProduction())
{
    app.UseDefaultFiles(new DefaultFilesOptions
    {
        FileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory()),
    });
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory()),
    });
}

app.MapGet("api/mealRange", (IMealSelector mealSelector) =>
{
    (DateTime oldestDate, DateTime newestDate) = mealSelector.GetDateRange();

    return new
    {
        oldestDate = oldestDate.ToString("o"),
        newestDate = newestDate.ToString("o")
    };
})
.WithName("GetMealRange")
.WithOpenApi();

app.MapGet("api/meals", ([FromQuery(Name = "date")] DateOnly date, IMealSelector mealSelector) =>
{
    DateTime dateTime = date.ToDateTime(TimeOnly.MinValue);
    (DateTime oldestDate, DateTime newestDate) = mealSelector.GetDateRange();
    if (dateTime < oldestDate || dateTime > newestDate)
        throw new NoMealsException(dateTime);

    Meal[] meals = mealSelector.GetMealsForDate(dateTime);
    return meals.Select(meal => 
        new
        {
            ingredients = meal.Ingredients.Select(ingredient => 
                           new
                           {
                    name = ingredient.Name,
                    quantity = ingredient.Quantity
                }),
            type = meal.MealType.ToFriendlyString(),
            preparation = meal.Preparation
        });
})
.WithName("GetMeals")
.WithOpenApi();

app.Run();

