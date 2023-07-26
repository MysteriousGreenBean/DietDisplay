using DietDisplay.API.Logic;
using DietDisplay.API.Logic.Database;
using DietDisplay.API.Logic.DateProvider;
using DietDisplay.API.Model;
using DietDisplay.API.Tests.TestHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietDisplay.API.Tests.Logic
{
    public class MealSelectorTests
    {
        [Test]
        public void GetDateRange_returnsDate30DaysIntoTheFutureAsNewestDate()
        {
            // Arrange
            var expectedNewestDate = DateTime.UtcNow.AddDays(30).Date;
            var databaseConnectionMock = new Mock<IDatabaseConnection>();
            var dateProviderMock = MockHelper.GetDefaultDateProvider();
            databaseConnectionMock.Setup(x => x.GetOldestAvailableDate()).Returns(DateTime.UtcNow.Date);

            var mealSelector = new MealSelector(databaseConnectionMock.Object, dateProviderMock.Object);

            // Act
            var (oldestDate, newestDate) = mealSelector.GetDateRange();

            // Assert
            Assert.That(newestDate, Is.EqualTo(expectedNewestDate));
        }

        [Test]
        public void GetDateRange_returnsDate7DaysAgoAsOldestDateIfDatabaseReturnsOlder()
        {
            // Arrange
            var expectedOldestDate = DateTime.UtcNow.AddDays(-7).Date;
            var databaseConnectionMock = new Mock<IDatabaseConnection>();
            var dateProviderMock = MockHelper.GetDefaultDateProvider();
            databaseConnectionMock.Setup(x => x.GetOldestAvailableDate()).Returns(DateTime.UtcNow.Date.AddDays(-150));

            var mealSelector = new MealSelector(databaseConnectionMock.Object, dateProviderMock.Object);

            // Act
            var (oldestDate, newestDate) = mealSelector.GetDateRange();

            // Assert
            Assert.That(oldestDate, Is.EqualTo(expectedOldestDate));
        }

        [Test]
        public void GetDateRange_returnsDateFromDatabaseIfCloserThanWeekAgo()
        {
            // Arrange
            var expectedOldestDate = DateTime.UtcNow.AddDays(-3).Date;
            var databaseConnectionMock = new Mock<IDatabaseConnection>();
            var dateProviderMock = MockHelper.GetDefaultDateProvider();
            databaseConnectionMock.Setup(x => x.GetOldestAvailableDate()).Returns(expectedOldestDate);

            var mealSelector = new MealSelector(databaseConnectionMock.Object, dateProviderMock.Object);

            // Act
            var (oldestDate, newestDate) = mealSelector.GetDateRange();

            // Assert
            Assert.That(oldestDate, Is.EqualTo(expectedOldestDate));
        }

        [Test]
        public void GetMealsForDate_returnsMealsForSpecificDate()
        {
            // Arrange
            var date = DateTime.UtcNow.Date.AddDays(15);
            var databaseConnectionMock = new Mock<IDatabaseConnection>();
            var dateProviderMock = MockHelper.GetDefaultDateProvider();
            var expectedMealData = new MealIgredientsData[] {
                new MealIgredientsData
                {
                    IngredientID = 1,
                    IngredientName = "Ingredient",
                    Quantity = 100,
                    MealID = 1,
                    Preparation = "Boil 'em, mash 'em, stick 'em in a stew",
                    MealType = "śniadanie",
                    DayID = 1,
                },
                new MealIgredientsData
                {
                    IngredientID = 2,
                    IngredientName = "PO-TA-TO-ES",
                    Quantity = 10,
                    MealID = 2,
                    Preparation = "Boil 'em, mash 'em, stick 'em in a stew",
                    MealType = "drugie śniadanie",
                    DayID = 1,
                },
            };
            databaseConnectionMock.Setup(x => x.GetMealsForDate(date)).Returns(expectedMealData);
            var mealSelector = new MealSelector(databaseConnectionMock.Object, dateProviderMock.Object);

            // Act
            var meals = mealSelector.GetMealsForDate(date);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(meals, Has.Length.EqualTo(2));
                Assert.That(meals[0].ID, Is.EqualTo(expectedMealData[0].MealID));
                Assert.That(meals[0].MealType, Is.EqualTo(MealType.Breakfast));
                Assert.That(meals[0].Preparation, Is.EqualTo(expectedMealData[0].Preparation));
                Assert.That(meals[0].Ingredients, Has.Length.EqualTo(1));
                Assert.That(meals[0].Ingredients[0].Name, Is.EqualTo(expectedMealData[0].IngredientName));
                Assert.That(meals[0].Ingredients[0].Quantity, Is.EqualTo(expectedMealData[0].Quantity));
                Assert.That(meals[1].ID, Is.EqualTo(expectedMealData[1].MealID));
                Assert.That(meals[1].MealType, Is.EqualTo(MealType.SecondBreakfast));
                Assert.That(meals[1].Preparation, Is.EqualTo(expectedMealData[1].Preparation));
                Assert.That(meals[1].Ingredients, Has.Length.EqualTo(1));
                Assert.That(meals[1].Ingredients[0].Name, Is.EqualTo(expectedMealData[1].IngredientName));
                Assert.That(meals[1].Ingredients[0].Quantity, Is.EqualTo(expectedMealData[1].Quantity));
            });
        }
    }
}
