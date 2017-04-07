using System;
using FakeItEasy;
using Toggled.Tests.Fixtures;
using Toggled.Tests.Helpers;
using Toggled.Togglers;
using Toggled.Traits;
using Xunit;

namespace Toggled.Tests.UnitTests.Toggles
{
    public class DependentFeatureToggleTests
    {
        [Theory, ToggledAutoData]
        public void GivenNullFeatureThrows(IFeatureContext featureContext, DependentFeatureToggler sut)
        {
            Assert.Throws<ArgumentNullException>(() => sut.IsEnabled(featureContext, null));
        }

        [Theory, ToggledAutoData]
        public void GivenNullFeatueContextThrowsException(IFeature feature, DependentFeatureToggler sut)
        {
            Assert.Throws<ArgumentNullException>(() => sut.IsEnabled(null, feature));
        }

        [Theory, ToggledAutoData]
        public void IgnoresFeatureWithoutDependentFeatureTrait(IFeatureContext featureContext, IFeature feature, DependentFeatureToggler sut)
        {
            bool? result = sut.IsEnabled(featureContext, feature);

            Assert.Null(result);
        }

        [Theory, ToggledAutoData]
        public void ChecksStateOfDependentFeatures(IFeatureContext featureContext, FeatureFixture feature, IFeature dependentFeature, DependentFeatureToggler sut)
        {
            A.CallTo(() => featureContext.IsEnabled(dependentFeature))
                .Returns(true);
            feature.Traits.Add(new DependentFeatureTrait(dependentFeature));

            sut.IsEnabled(featureContext, feature);

            A.CallTo(() => featureContext.IsEnabled(dependentFeature))
                .MustHaveHappened();
        }

        [Theory, ToggledAutoData]
        public void ChecksStateOfAllDependentFeatures(IFeatureContext featureContext, FeatureFixture feature,
            IFeature dependentFeature, DependentFeatureToggler sut)
        {
            A.CallTo(() => featureContext.IsEnabled(dependentFeature))
                .Returns(true);
            // Hey, it works!
            feature.Traits.Add(new DependentFeatureTrait(dependentFeature));
            feature.Traits.Add(new DependentFeatureTrait(dependentFeature));
            feature.Traits.Add(new DependentFeatureTrait(dependentFeature));

            sut.IsEnabled(featureContext, feature);

            A.CallTo(() => featureContext.IsEnabled(dependentFeature))
                .MustHaveHappened(Repeated.Exactly.Times(3));
        }

        [Theory, ToggledAutoData]
        public void ReturnsFalseWhenDependentFeatureIsDisabled(IFeatureContext featureContext, FeatureFixture feature,
            IFeature dependentFeature, DependentFeatureToggler sut)
        {
            A.CallTo(() => featureContext.IsEnabled(dependentFeature))
                .Returns(false);
            feature.Traits.Add(new DependentFeatureTrait(dependentFeature));

            bool? result = sut.IsEnabled(featureContext, feature);

            Assert.False(result);
        }

        [Theory, ToggledAutoData]
        public void ReturnsFalseWhenDependentFeatureIsEnabled(IFeatureContext featureContext, FeatureFixture feature,
            IFeature dependentFeature, DependentFeatureToggler sut)
        {
            A.CallTo(() => featureContext.IsEnabled(dependentFeature))
                .Returns(true);
            feature.Traits.Add(new DependentFeatureTrait(dependentFeature));

            bool? result = sut.IsEnabled(featureContext, feature);

            Assert.Null(result);
        }
    }
}