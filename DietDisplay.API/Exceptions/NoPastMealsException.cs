namespace DietDisplay.API.Exceptions
{
    public class NoPastMealsException : Exception
    {
        public NoPastMealsException(DateTime date) : base($"No meal plan was generated for {date.ToShortDateString()}")
        {
        }
    }
}
