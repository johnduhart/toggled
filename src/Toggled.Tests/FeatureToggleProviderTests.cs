using System;
using System.Collections.Generic;
using Toggled.Tests.Helpers;
using Toggled.Toggles;
using Toggled.Traits;
using Xunit;

namespace Toggled.Tests
{
    public class FeatureToggleProviderTests
    {
        [Fact]
        public void ConstructorThrowsExceptionWhenGivenNoFeatureToggles()
        {
            Assert.Throws<ArgumentException>(() => new FeatureToggleProvider(new IFeatureToggle[0]));
        }

        [Fact]
        public void ConstructorThrowsExceptionWhenGivenNullFeatureToggles()
        {
            Assert.Throws<ArgumentNullException>(() => new FeatureToggleProvider(null));
        }

        [Theory, ToggledAutoData]
        public void GetFeatureTogglesReturnsFeatureToggles(IFeatureToggle[] featureToggles)
        {
            var sut = new FeatureToggleProvider(featureToggles);

            IEnumerable<IFeatureToggle> result = sut.GetFeatureToggles();

            Assert.Same(featureToggles, result);
        }
    }
}