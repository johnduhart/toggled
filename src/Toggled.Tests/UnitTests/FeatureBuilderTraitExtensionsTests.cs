using System;
using System.Diagnostics.CodeAnalysis;
using FakeItEasy;
using Toggled.Tests.Helpers;
using Toggled.Traits;
using Xunit;

namespace Toggled.Tests.UnitTests
{
    [SuppressMessage("ReSharper", "InvokeAsExtensionMethod")]
    public class FeatureBuilderTraitExtensionsTests
    {
        private static void InterceptWithTrait(IFeatureBuilder featureBuilder, Action<object> withTraitCalled)
        {
            A.CallTo(() => featureBuilder.WithTrait(A<IFeatureTrait>.Ignored))
                    .WithAnyArguments()
                    .Invokes(call => withTraitCalled(call.Arguments[0]))
                    .Returns(featureBuilder);
        }

        public class WithDefaultValue
        {
            [Theory, ToggledAutoData]
            public void ThrowsWhenGivenNullFeatureBuilder(bool defaultValue)
            {
                Assert.Throws<ArgumentNullException>(
                    () => FeatureBuilderTraitExtensions.WithDefaultValue(null, defaultValue));
            }

            [Theory, ToggledAutoData]
            public void AddsDefaultValueTrait(IFeatureBuilder featureBuilder, bool defaultValue)
            {
                object defaultValueTrait = null;
                InterceptWithTrait(featureBuilder, o => defaultValueTrait = o);

                IFeatureBuilder result = FeatureBuilderTraitExtensions.WithDefaultValue(featureBuilder, defaultValue);

                Assert.Same(featureBuilder, result);
                Assert.NotNull(defaultValueTrait);
                Assert.IsType<DefaultValueTrait>(defaultValueTrait);
                Assert.Equal(defaultValue, ((DefaultValueTrait)defaultValueTrait).DefaultValue);
            }
        }

        public class DependentOn
        {
            [Theory, ToggledAutoData]
            public void ThrowsWhenGivenNullFeatureBuilder(IFeature feature)
            {
                Assert.Throws<ArgumentNullException>(
                    () => FeatureBuilderTraitExtensions.DependentOn(null, feature));
            }

            [Theory, ToggledAutoData]
            public void ThrowsWhenGivenNullDependentFeature(IFeatureBuilder featureBuilder)
            {
                Assert.Throws<ArgumentNullException>(
                    () => FeatureBuilderTraitExtensions.DependentOn(featureBuilder, null));
            }

            [Theory, ToggledAutoData]
            public void AddsDependentFeatureTrait(IFeatureBuilder featureBuilder, IFeature dependentFeature)
            {
                object dependentFeatureTrait = null;
                InterceptWithTrait(featureBuilder, o => dependentFeatureTrait = o);

                IFeatureBuilder result = FeatureBuilderTraitExtensions.DependentOn(featureBuilder, dependentFeature);

                Assert.Same(featureBuilder, result);
                Assert.NotNull(dependentFeatureTrait);
                Assert.IsType<DependentFeatureTrait>(dependentFeatureTrait);
                Assert.Equal(dependentFeature, ((DependentFeatureTrait)dependentFeatureTrait).DependentFeature);
            }
        }
    }
}