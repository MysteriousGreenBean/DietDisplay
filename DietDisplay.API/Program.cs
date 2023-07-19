﻿using DietDisplay.API;
using DietDisplay.API.Logic;
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
app.UseDefaultFiles();
app.UseStaticFiles();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};


app.MapGet("api/meals/{date}", (DateTime date, IMealSelector mealSelector) =>
{
    Meal[] meals = mealSelector.GetMealsFordate(date);
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

