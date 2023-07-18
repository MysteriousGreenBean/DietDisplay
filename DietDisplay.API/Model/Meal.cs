namespace DietDisplay.API.Model
{
    public class Meal
    {
        public int ID { get; init; }
        public Ingredient[] Ingredients { get; init; } = new Ingredient[0];
        public MealType MealType { get; init; }
        public string Preparation { get; init; } = string.Empty;
    }
}
