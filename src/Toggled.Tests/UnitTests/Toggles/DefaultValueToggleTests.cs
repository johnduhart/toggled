using System;
using System.Collections.Generic;
using Toggled.Exceptions;
using Toggled.Tests.Fixtures;
using Toggled.Tests.Helpers;
using Toggled.Toggles;
using Toggled.Traits;
using Xunit;

namespace Toggled.Tests.UnitTests.Toggles
{
    public class DefaultValueToggleTests
    {
        [Theory, ToggledAutoData]
        public void FeatureWithDefaultValueTraitShouldReturnDefaultValue(FeatureFixture feature,
            DefaultValueTrait defaultValueTrait, DefaultValueToggle sut)
        {
            feature.Traits.Add(defaultValueTrait);

            bool? result = sut.IsEnabled(feature);

            Assert.Equal(defaultValueTrait.DefaultValue, result);
        }

        [Theory, ToggledAutoData]
        public void FeatureWithoutDefaultValueTraitShouldReturnNull(FeatureFixture feature, DefaultValueToggle sut)
        {
            bool? result = sut.IsEnabled(feature);

            Assert.Null(result);
        }

        [Theory, ToggledAutoData]
        public void GivenNullFeatureThrows(DefaultValueToggle sut)
        {
            Assert.Throws<ArgumentNullException>(() => sut.IsEnabled(null));
        }

        [Theory, ToggledAutoData]
        public void FeatureWithMultipleDefaultValueTraitsThrows(FeatureFixture feature,
            IEnumerable<DefaultValueTrait> defaultValueTraits, DefaultValueToggle sut)
        {
            feature.Traits.AddRange(defaultValueTraits);

            Assert.Throws<InvalidFeatureException>(() => sut.IsEnabled(feature));
        }
    }
}