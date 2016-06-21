using System;
using System.Collections.Generic;
using Toggled.Tests.Helpers;
using Xunit;

namespace Toggled.Tests.UnitTests
{
    public class FeatureToggleProviderTests
    {
        [Fact]
        public void ConstructorThrowsExceptionWhenGivenNoFeatureToggles()
        {
            Assert.Throws<ArgumentException>(() => new FeatureTogglerSource(new IFeatureToggler[0]));
        }

        [Fact]
        public void ConstructorThrowsExceptionWhenGivenNullFeatureToggles()
        {
            Assert.Throws<ArgumentNullException>(() => new FeatureTogglerSource(null));
        }

        [Theory, ToggledAutoData]
        public void GetFeatureTogglesReturnsFeatureToggles(IFeatureToggler[] featureTogglers)
        {
            var sut = new FeatureTogglerSource(featureTogglers);

            IEnumerable<IFeatureToggler> result = sut.GetFeatureToggles();

            Assert.Same(featureTogglers, result);
        }
    }
}