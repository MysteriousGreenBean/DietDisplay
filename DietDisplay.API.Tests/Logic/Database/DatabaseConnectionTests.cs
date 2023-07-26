using DietDisplay.API.Exceptions;
using DietDisplay.API.Logic.Database;
using DietDisplay.API.Logic.DateProvider;
using DietDisplay.API.Tests.TestHelpers;
using NUnit.Framework;
using System.Data;

namespace DietDisplay.API.Tests.Logic.Database
{
    public class DatabaseConnectionTests
    {
        [Test]
        public void GetOldestAvailableDate_ShouldQueryDatabaseForOldestAvailableDate()
        {
            // Arrange
            var dateProvider = MockHelper.GetDefaultDateProvider();
            var dataAccessMock = new Mock<IDataAccess>();
            dataAccessMock.Setup(x => x.Query<DateTime>(It.IsAny<IQuery>())).Returns(new DateTime[] { DateTime.UtcNow.Date });
            var databaseConnection = new DatabaseConnection(dataAccessMock.Object, dateProvider.Object);

            // Act
            databaseConnection.GetOldestAvailableDate();

            // Assert
            dataAccessMock.Verify(x => x.Query<DateTime>(It.Is<IQuery>(query => QueryContains(query, "TOP 1", "Date", "DayMeals", "ORDER BY Date ASC"))), Times.Once);
        }

        [Test]
        public void GetOldestAvailableDate_ShouldReturnResultOfQueryWithUtcKind()
        {
            // Arrange
            var dataAccessMock = new Mock<IDataAccess>();
            var dateProvider = MockHelper.GetDefaultDateProvider();
            dataAccessMock.Setup(x => x.Query<DateTime>(It.IsAny<IQuery>())).Returns(new DateTime[] { DateTime.UtcNow.Date.AddDays(3) });
            var databaseConnection = new DatabaseConnection(dataAccessMock.Object, dateProvider.Object);

            // Act
            DateTime result = databaseConnection.GetOldestAvailableDate();
            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(result.Kind, Is.EqualTo(DateTimeKind.Utc));
                Assert.That(result.Date, Is.EqualTo(DateTime.UtcNow.Date.AddDays(3)));
            });
        }

        [Test]
        public void GetMealsForDate_ShouldReturnMealDataForSpecificDate()
        {
            // Arrange
            var expectedMealData = new MealIgredientsData[] {
                new MealIgredientsData
                {
                    IngredientID = 1,
                    IngredientName = "Ingredient",
                    Quantity = 100,
                    MealID = 1,
                    Preparation = "Boil 'em, mash 'em, stick 'em in a stew",
                    MealType = "Breakfast",
                    DayID = 1,
                }
            };
            var dateProvider = MockHelper.GetDefaultDateProvider();
            var dataAccessMock = new Mock<IDataAccess>();
            dataAccessMock
                .Setup(x => x.Query<int>(It.Is<IQuery>(query =>
                    QueryContains(query, "SELECT DayID FROM DayMeals WHERE Date")
                    && ParametersContain(query, "date", DateTime.UtcNow.Date))))
                .Returns(new int[] { 1 });

            dataAccessMock
                .Setup(x => x.Query<MealIgredientsData>(
                    It.Is<IQuery>(query =>
                        QueryContains(query, "SELECT", "FROM Ingredients", "INNER JOIN Meals", "WHERE m.DayID")
                        && ParametersContain(query, "dayMealID", 1))))
                .Returns(expectedMealData);
            var databaseConnection = new DatabaseConnection(dataAccessMock.Object, dateProvider.Object);

            // Act
            MealIgredientsData[] result = databaseConnection.GetMealsForDate(DateTime.UtcNow.Date);

            // Assert
            Assert.That(result[0], Is.SameAs(expectedMealData[0]));
        }

        [Test]
        public void GetMealsForDate_InitializesDayMealIfNotPresent()
        {
            // Arrange
            var dateProvider = MockHelper.GetDefaultDateProvider();
            var dataAccessMock = new Mock<IDataAccess>();
            dataAccessMock
                .Setup(x => x.Query<int>(It.Is<IQuery>(query =>
                                   QueryContains(query, "SELECT DayID FROM DayMeals WHERE Date")
                                                      && ParametersContain(query, "date", DateTime.UtcNow.Date))))
                .Returns(Array.Empty<int>());
            dataAccessMock
                .Setup(x => x.Query<int>(It.Is<IQuery>(query => QueryContains(query, "SELECT DISTINCT DayID FROM Meals"))))
                .Returns(new int[] { 1 });
            dataAccessMock
                .Setup(x => x.Execute(It.Is<IQuery>(query =>
                    QueryContains(query, "INSERT INTO DayMeals (Date, DayID) VALUES (@date, @dayID)")
                    && ParametersContain(query, "date", DateTime.UtcNow.Date)
                    && ParametersContain(query, "dayID", 1))))
                .Returns(1);
            var databaseConnection = new DatabaseConnection(dataAccessMock.Object, dateProvider.Object);

            // Act
            databaseConnection.GetMealsForDate(DateTime.UtcNow.Date);

            // Assert
            dataAccessMock.Verify(x => x.Execute(It.Is<IQuery>(query =>
                           QueryContains(query, "INSERT INTO DayMeals (Date, DayID) VALUES (@date, @dayID)")
                           && ParametersContain(query, "date", DateTime.UtcNow.Date)
                           && ParametersContain(query, "dayID", 1))), Times.Once);
        }

        [Test]
        public void GetMealsForDate_ThrowsNoMealsExceptionIfMealsInThePastWereNotFound()
        {
            // Arrange
            var dateProvider = MockHelper.GetDefaultDateProvider();
            var dataAccessMock = new Mock<IDataAccess>();
            dataAccessMock
                .Setup(x => x.Query<int>(It.Is<IQuery>(query =>
                    QueryContains(query, "SELECT DayID FROM DayMeals WHERE Date")
                    && ParametersContain(query, "date", DateTime.UtcNow.Date.AddDays(-6)))))
                .Returns(Array.Empty<int>());
            var databaseConnection = new DatabaseConnection(dataAccessMock.Object, dateProvider.Object);

            // Act and assert
            Assert.Throws<NoMealsException>(() => databaseConnection.GetMealsForDate(DateTime.UtcNow.Date.AddDays(-6)));
        }

        private bool ParametersContain(IQuery query, string field, object value)
        {
            return query.Parameters?.GetType()?.GetProperty(field)?.GetValue(query.Parameters)?.Equals(value) ?? false;
        }

        private bool QueryContains(IQuery query, params string[] strings)
        {
            foreach (string s in strings)
            {
                if (!query.Sql.Contains(s))
                    return false;
            }
            return true;
        }
    }
}