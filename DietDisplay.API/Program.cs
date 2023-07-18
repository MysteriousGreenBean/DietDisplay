using DietDisplay.API.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy("LocalReact", builder =>
{
    builder.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("LocalReact");
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("api/meals/{date}", (DateTime date) =>
{
    var meals = new[]
    {
        new Meal(new []
        {
            new Ingredient("Jajka", 2),
            new Ingredient("Masło", 100),
        },
        MealType.Snack,
        "Jajkuj masła")
    };
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

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

