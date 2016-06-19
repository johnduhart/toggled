using System;

namespace Toggled.Traits
{
    public static class FeatureBuilderTraitExtensions
    {
        public static IFeatureBuilder WithDefaultValue(this IFeatureBuilder featureBuilder, bool defaultValue)
        {
            if (featureBuilder == null)
                throw new ArgumentNullException(nameof(featureBuilder));

            featureBuilder.WithTrait(new DefaultValueTrait(defaultValue));
            return featureBuilder;
        }
    }
}