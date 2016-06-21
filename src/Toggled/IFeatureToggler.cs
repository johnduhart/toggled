namespace Toggled
{
    /// <summary>
    /// Logic that is applied to a feature to determine its current state
    /// </summary>
    public interface IFeatureToggler
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