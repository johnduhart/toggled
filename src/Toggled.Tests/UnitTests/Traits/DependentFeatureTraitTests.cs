using System;
using Toggled.Tests.Helpers;
using Toggled.Traits;
using Xunit;

namespace Toggled.Tests.UnitTests.Traits
{
    public class DependentFeatureTraitTests
    {
        [Fact]
        public void ConstructorThrowsExceptionOnNullFeature()
        {
            Assert.Throws<ArgumentNullException>(() => new DependentFeatureTrait(null));
        }

        [Theory, ToggledAutoData]
        public void ConstructorSetsDependentFeature(IFeature feature)
        {
            var sut = new DependentFeatureTrait(feature);

            Assert.Same(feature, sut.DependentFeature);
        }
    }
}