namespace DietDisplay.API.Model
{
    public enum MealType
    {
        Breakfast,
        SecondBreakfast,
        Dinner,
        Tea,
        Supper,
        Snack
    }

    public static class MealTypeExtensions
    {
        public static string ToFriendlyString(this MealType mealType)
        {
            return mealType switch
            {
                MealType.Breakfast => "Śniadanie",
                MealType.SecondBreakfast => "Drugie śniadanie",
                MealType.Dinner => "Obiad",
                MealType.Tea => "Podwieczorek",
                MealType.Supper => "Kolacja",
                MealType.Snack => "Przekąska",
                _ => throw new ArgumentOutOfRangeException(nameof(mealType), mealType, null)
            };
        }

        public static MealType FromFriendlyString(string mealType)
        {
            return mealType switch
            {
                "Śniadanie" => MealType.Breakfast,
                "Drugie śniadanie" => MealType.SecondBreakfast,
                "Obiad" => MealType.Dinner,
                "Podwieczorek" => MealType.Tea,
                "Kolacja" => MealType.Supper,
                "Przekąska" => MealType.Snack,
                _ => throw new ArgumentOutOfRangeException(nameof(mealType), mealType, null)
            };
        }
    }
}
