namespace Toggled
{
    // TODO: This naming sucks, find an alternative
    /// <summary>
    /// Represents a configuration source that may define a feature
    /// as enabled or disabled.
    /// </summary>
    public interface IFeatureToggle
    {
        /// <summary>
        /// Checks to see if a feature has a defined state.
        /// </summary>
        /// <param name="featureContext">The context that the feature currently being resolved in.</param>
        /// <param name="feature">The feature.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="feature"/> is <see langword="null" />.</exception>
        /// <returns>The state of the feature if it is defined; otherwise, <see langword="null" />.</returns>
        bool? IsEnabled(IFeatureContext featureContext, IFeature feature);
    }
}