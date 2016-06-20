using System;
using FakeItEasy;
using Toggled.Exceptions;
using Toggled.Tests.Helpers;
using Xunit;

namespace Toggled.Tests
{
    public class FeatureTests
    {
        public class IsEnabled
        {
            [Fact]
            public void ThrowsOnNullFeature()
            {
                Assert.Throws<ArgumentNullException>(() => Feature.IsEnabled(null));
            }

            [Theory, ToggledAutoData]
            public void ThrowsOnMissingContext(IFeature feature)
            {
                Assert.Throws<MissingFeatureContextException>(() => Feature.IsEnabled(feature));
            }

            [Theory, ToggledAutoData]
            public void ReturnsIsEnabledFromContext(IFeature feature, IFeatureContext context, bool expected)
            {
                A.CallTo(() => context.IsEnabled(feature))
                    .Returns(expected);

                bool result;
                using (ContextSwitcher.For(context))
                {
                    result = Feature.IsEnabled(feature);
                }

                Assert.Equal(expected, result);
                A.CallTo(() => context.IsEnabled(feature))
                    .MustHaveHappened();
            }
        }

        public class IsDisabled
        {
            [Fact]
            public void ThrowsOnNullFeature()
            {
                Assert.Throws<ArgumentNullException>(() => Feature.IsDisabled(null));
            }

            [Theory, ToggledAutoData]
            public void ThrowsOnMissingContext(IFeature feature)
            {
                Assert.Throws<MissingFeatureContextException>(() => Feature.IsDisabled(feature));
            }

            [Theory, ToggledAutoData]
            public void ReturnsIsEnabledFromContext(IFeature feature, IFeatureContext context, bool expected)
            {
                A.CallTo(() => context.IsEnabled(feature))
                    .Returns(expected);

                bool result;
                using (ContextSwitcher.For(context))
                {
                    result = Feature.IsDisabled(feature);
                }

                Assert.Equal(!expected, result);
                A.CallTo(() => context.IsEnabled(feature))
                    .MustHaveHappened();
            }
        }
    }
}
