using System;
using System.Diagnostics.CodeAnalysis;
using FakeItEasy;
using Toggled.Tests.Helpers;
using Xunit;

namespace Toggled.Tests
{
    [SuppressMessage("ReSharper", "InvokeAsExtensionMethod")]
    public class FeatureContextExtensionsTests
    {
        [Theory, ToggledAutoData]
        public void IsDisabledShouldInvertFeatureContext(IFeatureContext context, IFeature feature, bool enabled)
        {
            A.CallTo(() => context.IsEnabled(feature))
                .Returns(enabled);

            bool result = FeatureContextExtensions.IsDisabled(context, feature);

            Assert.Equal(!enabled, result);
            A.CallTo(() => context.IsEnabled(feature))
                .MustHaveHappened();
        }

        [Theory, ToggledAutoData]
        public void IsDisabledShouldThrowWhenGivenNullFeatureContext(IFeature feature)
        {
            var exception =
                Assert.Throws<ArgumentNullException>(() => FeatureContextExtensions.IsDisabled(null, feature));

            Assert.Contains("featureContext", exception.ParamName);
        }

        [Theory, ToggledAutoData]
        public void IsDisabledShouldThrowWhenGivenNullFeature(IFeatureContext context)
        {
            var exception =
                Assert.Throws<ArgumentNullException>(() => FeatureContextExtensions.IsDisabled(context, null));

            Assert.Contains("feature", exception.ParamName);
        }
    }
}