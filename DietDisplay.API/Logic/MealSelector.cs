using DietDisplay.API.Logic.Database;
using DietDisplay.API.Model;

namespace DietDisplay.API.Logic
{
    public class MealSelector : IMealSelector
    {
        private readonly IDatabaseConnection databaseConnection;

        public MealSelector(IDatabaseConnection databaseConnection)
        {
            this.databaseConnection = databaseConnection;
        }

        public Meal[] GetMealsFordate(DateTime date)
        {
            MealIgredientsData[] mealIgredientsDatas = databaseConnection.GetMealsForDate(date);
            return ConvertToMeals(mealIgredientsDatas);
        }

        private Meal[] ConvertToMeals(MealIgredientsData[] mealIgredientsDatas)
        {
            return mealIgredientsDatas.GroupBy(mi => mi.MealID, 
                (mi, group) =>
                {
                    MealIgredientsData firstMeal = group.First();
                    return new Meal
                    {
                        ID = mi,
                        MealType = firstMeal.MealType.FromFriendlyString(),
                        Preparation = firstMeal.Preparation,
                        Ingredients = group.Select(x => new Ingredient
                        {
                            Name = x.IngredientName,
                            Quantity = x.Quantity,
                        }).ToArray()
                    };
                }).ToArray();
        }
    }
}
