namespace DietDisplay.API.Exceptions
{
    public class NoMealsException : Exception
    {
        public NoMealsException(DateTime date) : base($"No meal plan was generated for {date.ToShortDateString()}")
        {
        }
    }
}
