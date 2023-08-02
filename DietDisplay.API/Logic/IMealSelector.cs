using DietDisplay.API.Logic.Cache;
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
        [Cached(CacheDuration.PerCalendarDay, CacheScope.PerArguments)]
        Meal[] GetMealsForDate(DateTime date);

        /// <summary>
        /// Gets available date range.
        /// </summary>
        /// <returns>Oldest date, meaning the first available meal plan and newest date, meaning the latest available meal plan date.</returns>
        [Cached(CacheDuration.PerCalendarDay)]
        (DateTime oldestDate, DateTime newestDate) GetDateRange();
    }
}
