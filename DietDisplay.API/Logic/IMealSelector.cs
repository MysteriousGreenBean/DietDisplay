using DietDisplay.API.Model;

namespace DietDisplay.API.Logic
{
    public interface IMealSelector
    {
        /// <summary>
        /// Gets meals for given date.
        /// </summary>
        /// <param name="date">Date for which meals should be selected. If the date was not assigned any meals yet - it will be assigned.</param>
        /// <returns>Array of meals for given date.</returns>
        Meal[] GetMealsFordate(DateTime date);
    }
}
