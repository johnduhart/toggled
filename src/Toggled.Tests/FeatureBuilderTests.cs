using System;
using System.Collections.Generic;
using Toggled.Tests.Helpers;
using Xunit;

namespace Toggled.Tests
{
    public class FeatureBuilderTests
    {
        [Fact]
        public void CreateThrowsWhenPassedNullFeatureId()
        {
            Assert.Throws<ArgumentNullException>(() => FeatureBuilder.Create(null));
        }

        [Theory, ToggledAutoData]
        public void CreateSetsAFeatureId(string featureId)
        {
            IFeature feature = FeatureBuilder.Create(featureId)
                .Build();

            Assert.Equal(featureId, feature.Id);
        }

        [Theory, ToggledAutoData]
        public void DescriptionThrowsWhenPassedNullDescription(string featureId)
        {
            Assert.Throws<ArgumentNullException>(() => FeatureBuilder.Create(featureId).Description(null));
        }

        [Theory, ToggledAutoData]
        public void DescriptionSetsDescription(string featureId, string description)
        {
            IFeature feature = FeatureBuilder.Create(featureId)
                .Description(description)
                .Build();

            Assert.Equal(description, feature.Description);
        }

        [Theory, ToggledAutoData]
        public void WithTraitThrowsWhenPassedNullTrait(string featureId)
        {
            Assert.Throws<ArgumentNullException>(() => FeatureBuilder.Create(featureId).WithTrait(null));
        }

        [Theory, ToggledAutoData]
        public void WithTraitAddsFeatureTrait(string featureId, IFeatureTrait trait)
        {
            IFeature feature = FeatureBuilder.Create(featureId)
                .WithTrait(trait)
                .Build();

            Assert.Contains(trait, feature.Traits);
        }
    }
}