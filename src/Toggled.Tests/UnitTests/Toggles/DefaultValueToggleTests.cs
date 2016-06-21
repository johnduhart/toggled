using System;
using System.Collections.Generic;
using Toggled.Exceptions;
using Toggled.Tests.Fixtures;
using Toggled.Tests.Helpers;
using Toggled.Togglers;
using Toggled.Traits;
using Xunit;

namespace Toggled.Tests.UnitTests.Toggles
{
    public class DefaultValueToggleTests
    {
        [Theory, ToggledAutoData]
        public void FeatureWithDefaultValueTraitShouldReturnDefaultValue(FeatureFixture feature,
            DefaultValueTrait defaultValueTrait, DefaultValueToggler sut)
        {
            feature.Traits.Add(defaultValueTrait);

            bool? result = sut.IsEnabled(null, feature);

            Assert.Equal(defaultValueTrait.DefaultValue, result);
        }

        [Theory, ToggledAutoData]
        public void FeatureWithoutDefaultValueTraitShouldReturnNull(FeatureFixture feature, DefaultValueToggler sut)
        {
            bool? result = sut.IsEnabled(null, feature);

            Assert.Null(result);
        }

        [Theory, ToggledAutoData]
        public void GivenNullFeatureThrows(DefaultValueToggler sut)
        {
            Assert.Throws<ArgumentNullException>(() => sut.IsEnabled(null, null));
        }

        [Theory, ToggledAutoData]
        public void FeatureWithMultipleDefaultValueTraitsThrows(FeatureFixture feature,
            IEnumerable<DefaultValueTrait> defaultValueTraits, DefaultValueToggler sut)
        {
            feature.Traits.AddRange(defaultValueTraits);

            Assert.Throws<InvalidFeatureException>(() => sut.IsEnabled(null, feature));
        }
    }
}