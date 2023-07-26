using DietDisplay.API.Exceptions;
using DietDisplay.API.Logic.DateProvider;

namespace DietDisplay.API.Logic.Database
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private readonly IDataAccess dataAccess;
        private readonly IDateProvider dateProvider;
        private int[] dayIds = Array.Empty<int>();

        public DatabaseConnection(IDataAccess dataAccess, IDateProvider dateProvider)
        {
            this.dataAccess = dataAccess;
            this.dateProvider = dateProvider;
        }

        /// <inheritdoc/>
        public DateTime GetOldestAvailableDate()
        {
            string query = "SELECT TOP 1 Date FROM DayMeals ORDER BY Date ASC";
            return DateTime.SpecifyKind(dataAccess.Query<DateTime>(new Query { Sql = query }).SingleOrDefault(dateProvider.GetCurrentUtcDate()), DateTimeKind.Utc);
        }

        /// <inheritdoc/>
        public MealIgredientsData[] GetMealsForDate(DateTime date)
        {
            int dayMealID = GetDayMealID(date);
            return GetMealsFromDay(dayMealID);
        }

        private int GetDayMealID(DateTime date)
        {
            string query = "SELECT DayID FROM DayMeals WHERE Date = @date";
            int dayID = dataAccess.Query<int>(new Query { Sql = query, Parameters = new { date = date.Date } }).SingleOrDefault();

            if (dayID == 0 && date.Date < dateProvider.GetCurrentUtcDate())
                throw new NoMealsException(date);

            return dayID == 0 ? InitializeDayMeal(date).DayID : dayID;
        }

        private DayMealData InitializeDayMeal(DateTime date)
        {
            string query = "INSERT INTO DayMeals (Date, DayID) VALUES (@date, @dayID)";
            int dayID = GetRandomDayID();
            dataAccess.Execute(new Query { Sql = query, Parameters = new { date, dayID } });
            return new DayMealData { Date = date, DayID = dayID };
        }

        private int GetRandomDayID()
        {
            if (dayIds.Length == 0)
                LoadAllAvailableDayIDs();

            return dayIds[new Random().Next(dayIds.Length)];
        }

        private void LoadAllAvailableDayIDs()
        {
            string query = "SELECT DISTINCT DayID FROM Meals;";
            dayIds = dataAccess.Query<int>(new Query { Sql = query }).ToArray();
        }

        private MealIgredientsData[] GetMealsFromDay(int dayMealID)
        {
            string query = @"SELECT 
                    i.ID AS IngredientID,
                    i.Name AS IngredientName,
                    i.Quantity,
                    m.ID AS MealID,
                    m.Preparation,
                    m.MealType,
                    m.DayID
                FROM Ingredients i
                INNER JOIN Meals m ON i.MealID = m.ID
                WHERE m.DayID = @dayMealID;";

            return dataAccess.Query<MealIgredientsData>(new Query { Sql = query, Parameters = new { dayMealID }}).ToArray();
        }
    }
}
