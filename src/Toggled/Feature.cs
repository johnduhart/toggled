using System;
using Toggled.Exceptions;

namespace Toggled
{
    /// <summary>
    /// An optional static entry point for Toggled that can be easily referenced
    /// </summary>
    /// <remarks>
    /// Before using the methods on <see cref="Feature"/>, <see cref="Context"/> is required
    /// to be set.
    /// </remarks>
    public static class Feature
    {
        /// <summary>
        /// The <see cref="IFeatureContext"/> used by the methods on <see cref="Feature"/>.
        /// </summary>
        public static IFeatureContext Context;

        /// <summary>
        /// Check to see if the given feature is enabled.
        /// </summary>
        /// <param name="feature">The feature</param>
        /// <exception cref="ArgumentNullException"><paramref name="feature"/> is <see langword="null" />.</exception>
        /// <exception cref="MissingFeatureContextException"><see cref="Feature.Context"/> is <see langword="null" />.</exception>
        /// <returns><c>true</c> if the feature is enabled; otherwise, <c>false</c>.</returns>
        public static bool IsEnabled(IFeature feature)
        {
            if (feature == null)
                throw new ArgumentNullException(nameof(feature));

            if (Context == null)
                throw new MissingFeatureContextException();

            return Context.IsEnabled(feature);
        }

        /// <summary>
        /// Check to see if the given feature is disabled.
        /// </summary>
        /// <param name="feature">The feature</param>
        /// <exception cref="ArgumentNullException"><paramref name="feature"/> is <see langword="null" />.</exception>
        /// <exception cref="MissingFeatureContextException"><see cref="Feature.Context"/> is <see langword="null" />.</exception>
        /// <returns><c>true</c> if the feature is disabled; otherwise, <c>false</c>.</returns>
        public static bool IsDisabled(IFeature feature)
        {
            return !IsEnabled(feature);
        }
    }
}