using DietDisplay.API.Tests.TestHelpers;
using IInvocation = Castle.DynamicProxy.IInvocation;
using TestedCache = DietDisplay.API.Logic.Cache.Cache;

namespace DietDisplay.API.Tests.Logic.Cache
{
    public class CacheTests
    {
        [Test]
        public void CacheMethodInvocationPerCalendarDay_WhenCalledWithCacheKeyAndInvocation_ThenProceedsInvocationAndSetsCacheValue()
        {
            // Arrange
            var cacheKey = "cacheKey";
            var invocation = new Mock<IInvocation>();
            var dateProvider = MockHelper.GetDefaultDateProvider();
            var cachedObject = "cachedObject";
            var cache = new TestedCache(dateProvider.Object);
            invocation.Setup(i => i.Proceed());
            invocation.SetupGet(i => i.ReturnValue).Returns(cachedObject);

            // Act
            cache.CacheMethodInvocationPerCalendarDay(cacheKey, invocation.Object);

            // Assert
            invocation.Verify(i => i.Proceed(), Times.Once);
            invocation.VerifyGet(i => i.ReturnValue, Times.Once);
            Assert.That(cache.GetPerCalendarDeyCacheValue(cacheKey), Is.SameAs(cachedObject));
        }

        [Test]
        public void GetPerCalendarDayCacheValue_ReturnsNullIfChacheEntryWithProvidedKeyDoesNotExist()
        {
            // Arrange
            var dateProvider = MockHelper.GetDefaultDateProvider();
            var cache = new TestedCache(dateProvider.Object);

            // Act
            var result = cache.GetPerCalendarDeyCacheValue("cacheKey");

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetPerCalendarDayCacheValue_ReturnNullIfCalendarDateHasChanged()
        {
            // Arrange
            var cacheKey = "cacheKey";
            var invocation = new Mock<IInvocation>();
            var dateProvider = MockHelper.GetDefaultDateProvider();
            var cachedObject = "cachedObject";
            var cache = new TestedCache(dateProvider.Object);
            invocation.Setup(i => i.Proceed());
            invocation.SetupGet(i => i.ReturnValue).Returns(cachedObject);

            cache.CacheMethodInvocationPerCalendarDay(cacheKey, invocation.Object);

            // Act
            dateProvider.Setup(d => d.GetCurrentUtcDate()).Returns(DateTime.UtcNow.AddDays(1));
            var result = cache.GetPerCalendarDeyCacheValue(cacheKey);

            Assert.That(result, Is.Null);
        }
    }
}
