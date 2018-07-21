using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoFixture;
using AutoFixture.Xunit2;

namespace UrlShorteningService.Service.Tests.Infrastructure
{
    public class DefaultAutoDataAttribute : AutoDataAttribute
    {
        private readonly string _methodName;

        public DefaultAutoDataAttribute()
            : base(() => new Fixture().Customize(new DefaultCustomization()))
        {
        }

        public DefaultAutoDataAttribute(string methodName)
            : this()
        {
            _methodName = methodName;
        }

        // Generates data injection parameters for each predefined part from test method sequence or sequence with single element for regular usage.
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (_methodName == null)
            {
                return base.GetData(testMethod);
            }

            MethodInfo methodInfo = null;
            for (var reflectionType = testMethod.DeclaringType; reflectionType != null; reflectionType = reflectionType.GetTypeInfo().BaseType)
            {
                methodInfo = reflectionType.GetRuntimeMethods()
                    .FirstOrDefault(m => m.Name == _methodName);
                if (methodInfo != null)
                    break;
            }

            if (methodInfo == null || !methodInfo.IsStatic)
            {
                return null;
            }

            return methodInfo.Invoke(null, new object[0]) is IEnumerable<object> obj ? obj.Select(s => base.GetData(testMethod).Single()) : null;
        }
    }
}