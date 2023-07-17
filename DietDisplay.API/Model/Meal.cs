namespace DietDisplay.API.Model
{
    public class Meal
    {
        public Ingredient[] Ingredients { get; }
        public MealType MealType { get; }
        public string Preparation { get; }

        public Meal(Ingredient[] ingredients, MealType mealType, string preparation)
        {
            Ingredients = ingredients;
            MealType = mealType;
            Preparation = preparation;
        }
    }
}
