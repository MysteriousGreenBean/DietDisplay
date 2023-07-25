using DietDisplay.API.Logic.Database;
using NUnit.Framework;
using System.Data;

namespace DietDisplay.API.Tests
{
    public class DatabaseConnectionTests
    {
        [Test]
        public void GetOldestAvailableDate_ShouldQueryDatabaseForOldestAvailableDate()
        {
            // Arrange
            var dataAccessMock = new Mock<IDataAccess>();
            dataAccessMock.Setup(x => x.Query<DateTime>(It.IsAny<string>(), null)).Returns(new DateTime[] { DateTime.UtcNow.Date });
            var databaseConnection = new DatabaseConnection(dataAccessMock.Object);

            // Act
            databaseConnection.GetOldestAvailableDate();
            
            // Assert
            dataAccessMock.Verify(x => x.Query<DateTime>(It.Is<string>(query => QueryContains(query, "TOP 1", "Date", "DayMeals", "ORDER BY Date ASC")), null), Times.Once);
        }

        // GetOldestAvailableDate should return the result of the query with specified UTC kind
        [Test]
        public void GetOldestAvailableDate_ShouldReturnResultOfQueryWithUtcKind()
        {
            // Arrange
            var dataAccessMock = new Mock<IDataAccess>();
            
            dataAccessMock.Setup(x => x.Query<DateTime>(It.IsAny<string>(), null)).Returns(new DateTime[] { DateTime.UtcNow.Date.AddDays(3) });
            var databaseConnection = new DatabaseConnection(dataAccessMock.Object);

            // Act
            DateTime result = databaseConnection.GetOldestAvailableDate();

            // Assert
            Assert.That(result.Kind, Is.EqualTo(DateTimeKind.Utc));
            Assert.That(result.Date, Is.EqualTo(DateTime.UtcNow.Date.AddDays(3)));
        }


        private bool QueryContains(string query, params string[] strings)
        {
            foreach (string s in strings)
            {
                if (!query.Contains(s))
                    return false;
            }
            return true;
        }
    }
}