namespace DietDisplay.API.Logic.Database
{
    public interface IDatabaseConnection
    {
        /// <summary>
        /// Gets meals for given date.
        /// </summary>
        /// <param name="date">Date for which meals should be returned.</param>
        /// <returns><see cref="MealIgredientsData"/> array containing data of all ingredients and meals.</returns>
        MealIgredientsData[] GetMealsForDate(DateTime date);
    }
}
