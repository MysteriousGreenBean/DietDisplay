namespace DietDisplay.API.Logic.Database
{
    public class MealIgredientsData
    {
        public int IngredientID { get; init; }
        public string IngredientName { get; init; } = string.Empty;
        public int Quantity { get; init; }
        public int MealID { get; init; }
        public string Preparation { get; init; } = string.Empty;
        public string MealType { get; init; } = string.Empty;
        public int DayID { get; init; }
    }
}
