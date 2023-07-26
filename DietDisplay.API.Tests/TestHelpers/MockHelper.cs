using DietDisplay.API.Logic.DateProvider;

namespace DietDisplay.API.Tests.TestHelpers
{
    internal static class MockHelper
    {
        public static Mock<IDateProvider> GetDefaultDateProvider()
        {
            var dateProvider = new Mock<IDateProvider>();
            dateProvider.Setup(d => d.GetCurrentUtcDate()).Returns(DateTime.UtcNow.Date);
            return dateProvider;
        }
    }
}
