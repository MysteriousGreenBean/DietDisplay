namespace DietDisplay.API.Logic.Database
{
    public class MealIgredientsData
    {
        public required int IngredientID { get; init; }
        public required string IngredientName { get; init; }
        public required int Quantity { get; init; }
        public required int MealID { get; init; }
        public required string Preparation { get; init; }
        public required string MealType { get; init; }
        public required int DayID { get; init; }
    }
}
