using System;

namespace Toggled
{
    /// <summary>
    /// Helper methods for <see cref="IFeatureContext"/>
    /// </summary>
    public static class FeatureContextExtensions
    {
        /// <summary>
        /// Checks to see if a feature is disabled.
        /// </summary>
        /// <param name="featureContext">The feature context.</param>
        /// <param name="feature">The feature.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="featureContext"/> is <see langword="null" />.</exception>
        /// <exception cref="System.ArgumentNullException"><paramref name="feature"/> is <see langword="null" />.</exception>
        /// <exception cref="Exceptions.FeatureStateNotFoundException">The given feature has no value assoicated with it.</exception>
        /// <returns><c>true</c> if the feature is disabled; otherwise, <c>false</c>.</returns>
        public static bool IsDisabled(this IFeatureContext featureContext, IFeature feature)
        {
            if (featureContext == null)
                throw new ArgumentNullException(nameof(featureContext));
            if (feature == null)
                throw new ArgumentNullException(nameof(feature));

            return !featureContext.IsEnabled(feature);
        }
    }
}