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
            cacheMock.Setup(x => x.GetPerCalendarDeyCacheValue(It.IsAny<string>())).Returns(cachedObject);

            // Act
            interceptor.Intercept(invocationMock.Object);

            // Assert
            cacheMock.Verify(x => x.GetPerCalendarDeyCacheValue(It.IsAny<string>()), Times.Once);
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
            cacheMock.Verify(x => x.GetPerCalendarDeyCacheValue(It.IsAny<string>()), Times.Never);
            invocationMock.VerifySet(x => x.ReturnValue = It.IsAny<object>(), Times.Never);
        }

        [Cached(CacheScope.PerCalendarDay)]
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
