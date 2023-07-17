namespace DietDisplay.API.Model
{
    public class Ingredient
    {
        public string Name { get; }
        public int Quantity { get; }

        public Ingredient(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
