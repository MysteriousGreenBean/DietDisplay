﻿using Dapper;
using DietDisplay.API.Exceptions;
using System.Data;
using System.Data.SqlClient;

namespace DietDisplay.API.Logic.Database
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private readonly string connectionString;
        private int[] dayIds = Array.Empty<int>();

        public DatabaseConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <inheritdoc/>
        public DateTime GetOldestAvailableDate()
        {
            using IDbConnection connection = OpenConnection();
            string query = "SELECT TOP 1 Date FROM DayMeals ORDER BY Date ASC";
            return connection.Query<DateTime>(query).SingleOrDefault(DateTime.UtcNow.Date);
        }

        /// <inheritdoc/>
        public MealIgredientsData[] GetMealsForDate(DateTime date)
        {
            using IDbConnection connection = OpenConnection();

            int dayMealID = GetDayMealID(connection, date);
            return GetMealsFromDay(connection, dayMealID);
        }

        private IDbConnection OpenConnection()
        {
            IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        private int GetDayMealID(IDbConnection connection, DateTime date)
        {
            string query = "SELECT DayID FROM DayMeals WHERE Date = @date";
            int dayID = connection.Query<int>(query, new { date = date.Date }).SingleOrDefault();

            if (dayID == 0 && date.Date < DateTime.UtcNow.Date)
                throw new NoMealsException(date);

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
