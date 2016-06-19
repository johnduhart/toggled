using System;
using System.Diagnostics.CodeAnalysis;
using FakeItEasy;
using Toggled.Tests.Helpers;
using Toggled.Traits;
using Xunit;

namespace Toggled.Tests
{
    [SuppressMessage("ReSharper", "InvokeAsExtensionMethod")]
    public class FeatureBuilderTraitExtensionsTests
    {
        [Theory, ToggledAutoData]
        public void WithDefaultValueAddsDefaultValueTrait(IFeatureBuilder featureBuilder, bool defaultValue)
        {
            object defaultValueTrait = null;
            A.CallTo(() => featureBuilder.WithTrait(A<IFeatureTrait>.Ignored))
                .WithAnyArguments()
                .Invokes(call => defaultValueTrait = call.Arguments[0])
                .Returns(featureBuilder);

            IFeatureBuilder result = FeatureBuilderTraitExtensions.WithDefaultValue(featureBuilder, defaultValue);

            Assert.Same(featureBuilder, result);
            Assert.NotNull(defaultValueTrait);
            Assert.IsType<DefaultValueTrait>(defaultValueTrait);
            Assert.Equal(defaultValue, ((DefaultValueTrait) defaultValueTrait).DefaultValue);
        }

        [Theory, ToggledAutoData]
        public void WithDefaultThrowsWhenGivenNullFeatureBuilder(bool defaultValue)
        {
            Assert.Throws<ArgumentNullException>(
                () => FeatureBuilderTraitExtensions.WithDefaultValue(null, defaultValue));
        }
    }
}