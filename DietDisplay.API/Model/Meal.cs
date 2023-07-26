namespace DietDisplay.API.Model
{
    public class Meal
    {
        public required int ID { get; init; }
        public required Ingredient[] Ingredients { get; init; }
        public required MealType MealType { get; init; }
        public required string Preparation { get; init; }
    }
}
