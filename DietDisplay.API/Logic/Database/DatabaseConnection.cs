using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DietDisplay.API.Logic.Database
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private readonly string connectionString;
        private int[] dayIds = new int[0];

        public DatabaseConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <inheritdoc/>
        public MealIgredientsData[] GetMealsForDate(DateTime date)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int dayMealID = GetDayMealID(connection, date);
                return GetMealsFromDay(connection, dayMealID);
            }
        }

        private int GetDayMealID(IDbConnection connection, DateTime date)
        {
            string query = "SELECT DayID FROM DayMeals WHERE Date = @date";
            int dayID = connection.Query<int>(query, new { date = date.Date }).SingleOrDefault();

            return dayID == 0 ? InitializeDayMeal(connection, date).DayID : dayID;
        }

        private DayMealData InitializeDayMeal(IDbConnection connection, DateTime date)
        {
            string query = "INSERT INTO DayMeals (Date, DayID) VALUES (@date, @dayID)";
            int dayID = GetRandomDayID(connection);
            connection.Execute(query, new { date, dayID });
            return new DayMealData { Date = date, DayID = dayID };
        }

        private int GetRandomDayID(IDbConnection connection)
        {
            if (dayIds.Length == 0)
                LoadAllAvailableDayIDs(connection);

            return dayIds[new Random().Next(dayIds.Length)];
        }

        private void LoadAllAvailableDayIDs(IDbConnection connection)
        {
            string query = "SELECT DISTINCT DayID FROM Meals;";
            dayIds = connection.Query<int>(query).ToArray();
        }

        private MealIgredientsData[] GetMealsFromDay(IDbConnection connection,int dayMealID)
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

            return connection.Query<MealIgredientsData>(query, new { dayMealID }).ToArray();
        }
    }
}
