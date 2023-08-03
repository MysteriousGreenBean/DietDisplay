using DietDisplay.API.Logic.Cache;
using System.Globalization;
using System.Reflection;
using IInvocation = Castle.DynamicProxy.IInvocation;

namespace DietDisplay.API.Tests.Logic.Cache
{
    public class CacheInterceptorTests
    {
        [Test]
        public void Intercept_WhenMethodIsNotCached_ShouldBeCached()
        {
            // Arrange
            var cacheMock = new Mock<ICache>();
            var invocationMock = new Mock<IInvocation>();
            invocationMock.Setup(x => x.Method).Returns(typeof(CacheInterceptorTests).GetMethod(nameof(MockedCachedPerCalendarDayMethod))!);
            invocationMock.Setup(x => x.TargetType).Returns(typeof(CacheInterceptorTests));
            var interceptor = new CacheInterceptor(cacheMock.Object);

            // Act
            interceptor.Intercept(invocationMock.Object);

            // Assert
            cacheMock.Verify(x => x.CacheMethodInvocationPerCalendarDay(It.IsAny<string>(), invocationMock.Object), Times.Once);
        }

        [Test]
        public void Intercept_WhenMethodIsCached_ShouldReturnCachedValue()
        {
            // Arrange
            var cachedObject = "cachedObject";
            var cacheMock = new Mock<ICache>();
            var invocationMock = new Mock<IInvocation>();
            var interceptor = new CacheInterceptor(cacheMock.Object);
            invocationMock.Setup(x => x.Method).Returns(typeof(CacheInterceptorTests).GetMethod(nameof(MockedCachedPerCalendarDayMethod))!);
            invocationMock.Setup(x => x.TargetType).Returns(typeof(CacheInterceptorTests));
            cacheMock.Setup(x => x.GetPerCalendarDayCacheValue(It.IsAny<string>())).Returns(cachedObject);

            // Act
            interceptor.Intercept(invocationMock.Object);

            // Assert
            cacheMock.Verify(x => x.GetPerCalendarDayCacheValue(It.IsAny<string>()), Times.Once);
            invocationMock.VerifySet(x => x.ReturnValue = cachedObject, Times.Once);
        }

        [Test]
        public void Intercept_WhenMethodIsNotMarkedWithAttributeItShouldJustProceed()
        {
            // Arrange
            var cacheMock = new Mock<ICache>();
            var invocationMock = new Mock<IInvocation>();
            var interceptor = new CacheInterceptor(cacheMock.Object);
            invocationMock.Setup(x => x.Method).Returns(typeof(CacheInterceptorTests).GetMethod(nameof(EmptyMethod))!);
            invocationMock.Setup(x => x.TargetType).Returns(typeof(CacheInterceptorTests));

            // Act
            interceptor.Intercept(invocationMock.Object);

            // Assert
            invocationMock.Verify(x => x.Proceed(), Times.Once);
            cacheMock.Verify(x => x.GetPerCalendarDayCacheValue(It.IsAny<string>()), Times.Never);
            invocationMock.VerifySet(x => x.ReturnValue = It.IsAny<object>(), Times.Never);
        }

        [Test]
        public void Intercept_WhenMetodIsMarkedWithScopePerArgumentsItShouldGenerateDifferentCacheForDifferentArguments()
        {
            var cacheMock = new Mock<ICache>();
            var interceptor = new CacheInterceptor(cacheMock.Object);
            var invocation1Mock = new Mock<IInvocation>();
            invocation1Mock.Setup(x => x.Method).Returns(typeof(CacheInterceptorTests).GetMethod(nameof(MockedCachedPerCalendarDayPerArgumentsMethod))!);
            invocation1Mock.Setup(x => x.TargetType).Returns(typeof(CacheInterceptorTests));
            invocation1Mock.Setup(x => x.Arguments).Returns(new object[] { 1, 2, 3 });

            interceptor.Intercept(invocation1Mock.Object);

            var invocation2Mock = new Mock<IInvocation>();
            invocation2Mock.Setup(x => x.Method).Returns(typeof(CacheInterceptorTests).GetMethod(nameof(MockedCachedPerCalendarDayPerArgumentsMethod))!);
            invocation2Mock.Setup(x => x.TargetType).Returns(typeof(CacheInterceptorTests));
            invocation2Mock.Setup(x => x.Arguments).Returns(new object[] { "test", "1", "t2" });

            interceptor.Intercept(invocation2Mock.Object);

            cacheMock.Verify(x => x.CacheMethodInvocationPerCalendarDay(It.IsAny<string>(), invocation1Mock.Object), Times.Exactly(1));
            cacheMock.Verify(x => x.CacheMethodInvocationPerCalendarDay(It.IsAny<string>(), invocation2Mock.Object), Times.Exactly(1));
        }

        [Test]
        public void Intercept_WhenMethodIsMarkedWithScopePerArgumentsItShouldCacheMethodOnlyOnce()
        {
            string? cachedKey = null;
            var cacheMock = new Mock<ICache>();
            var interceptor = new CacheInterceptor(cacheMock.Object);
            var invocationMock = new Mock<IInvocation>();
            invocationMock.Setup(x => x.Method).Returns(typeof(CacheInterceptorTests).GetMethod(nameof(MockedCachedPerCalendarDayPerArgumentsMethod))!);
            invocationMock.Setup(x => x.TargetType).Returns(typeof(CacheInterceptorTests));
            invocationMock.Setup(x => x.Arguments).Returns(new object[] { 1, 2, 3 });
            cacheMock.Setup(x => x.CacheMethodInvocationPerCalendarDay(It.IsAny<string>(), invocationMock.Object)).Callback<string, IInvocation>((key, invocation) => cachedKey = key);
            cacheMock.Setup(x => x.GetPerCalendarDayCacheValue(It.IsAny<string>())).Returns<string>(key => key == cachedKey ? "cachedObject" : null);

            interceptor.Intercept(invocationMock.Object);
            interceptor.Intercept(invocationMock.Object);

            cacheMock.Verify(x => x.CacheMethodInvocationPerCalendarDay(It.IsAny<string>(), invocationMock.Object), Times.Exactly(1));
        }

        [Cached(CacheDuration.PerCalendarDay, CacheScope.PerArguments)]
        public void MockedCachedPerCalendarDayPerArgumentsMethod()
        {

        }

        [Cached(CacheDuration.PerCalendarDay)]
        public void MockedCachedPerCalendarDayMethod()
        {

        }

        public void EmptyMethod()
        {

        }

        class MethodInfoMock : MethodInfo
        {
            public Type[] DefinedAttributeTypes { get; set; } = new Type[0];
    

            public override ICustomAttributeProvider ReturnTypeCustomAttributes => throw new NotImplementedException();

            public override MethodAttributes Attributes => throw new NotImplementedException();

            public override RuntimeMethodHandle MethodHandle => throw new NotImplementedException();

            public override Type? DeclaringType => throw new NotImplementedException();

            public override string Name => throw new NotImplementedException();

            public override Type? ReflectedType => throw new NotImplementedException();

            public override MethodInfo GetBaseDefinition()
            {
                throw new NotImplementedException();
            }

            public override object[] GetCustomAttributes(bool inherit)
            {
                throw new NotImplementedException();
            }

            public override object[] GetCustomAttributes(Type attributeType, bool inherit)
            {
                throw new NotImplementedException();
            }

            public override MethodImplAttributes GetMethodImplementationFlags()
            {
                throw new NotImplementedException();
            }

            public override ParameterInfo[] GetParameters()
            {
                throw new NotImplementedException();
            }

            public override object? Invoke(object? obj, BindingFlags invokeAttr, Binder? binder, object?[]? parameters, CultureInfo? culture)
            {
                throw new NotImplementedException();
            }

            public override bool IsDefined(Type attributeType, bool inherit)
            {
                if (DefinedAttributeTypes.Contains(attributeType))
                    return true;
                return false;
            }
        }
    }
}
