using System;

namespace Toggled.Traits
{
    /// <summary>
    /// Helper methods for adding traits using a <see cref="IFeatureBuilder"/>
    /// </summary>
    public static class FeatureBuilderTraitExtensions
    {
        /// <summary>
        /// Adds a default value trait to the feature.
        /// </summary>
        /// <param name="featureBuilder">The feature builder.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="featureBuilder"/> is <see langword="null" />.</exception>
        /// <returns>The feature builder given in <paramref name="featureBuilder"/>.</returns>
        public static IFeatureBuilder WithDefaultValue(this IFeatureBuilder featureBuilder, bool defaultValue)
        {
            if (featureBuilder == null)
                throw new ArgumentNullException(nameof(featureBuilder));

            featureBuilder.WithTrait(new DefaultValueTrait(defaultValue));
            return featureBuilder;
        }

        /// <summary>
        /// Adds a dependency trait to the feature.
        /// </summary>
        /// <param name="featureBuilder">The feature builder.</param>
        /// <param name="dependentFeature">The feature to be dependent on.</param>
        /// <exception cref="ArgumentNullException">Either <paramref name="featureBuilder"/> or <paramref name="dependentFeature"/> is <see langword="null" />.</exception>
        /// <returns>The feature builder given in <paramref name="featureBuilder"/>.</returns>
        public static IFeatureBuilder DependentOn(this IFeatureBuilder featureBuilder, IFeature dependentFeature)
        {
            if (featureBuilder == null)
                throw new ArgumentNullException(nameof(featureBuilder));
            if (dependentFeature == null)
                throw new ArgumentNullException(nameof(dependentFeature));

            featureBuilder.WithTrait(new DependentFeatureTrait(dependentFeature));
            return featureBuilder;
        }
    }
}