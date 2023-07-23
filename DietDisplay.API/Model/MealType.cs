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

        public static MealType FromFriendlyString(this string mealType)
        {
            return mealType.ToLowerInvariant() switch
            {
                "śniadanie" => MealType.Breakfast,
                "drugie śniadanie" => MealType.SecondBreakfast,
                "obiad" => MealType.Dinner,
                "podwieczorek" => MealType.Tea,
                "kolacja" => MealType.Supper,
                "przekąska" => MealType.Snack,
                _ => throw new ArgumentOutOfRangeException(nameof(mealType), mealType)
            };
        }
    }
}
