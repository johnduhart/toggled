using System;

namespace Toggled.Traits
{
    /// <summary>
    /// Helper methods for adding traits using a <see cref="IFeatureBuilder"/>
    /// </summary>
    public static class FeatureBuilderTraitExtensions
    {
        /// <summary>
        /// Adds a default value to the feature.
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
    }
}