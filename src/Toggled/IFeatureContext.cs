namespace Toggled
{
    /// <summary>
    /// Provides the interface for checking on the state of a Feature
    /// </summary>
    public interface IFeatureContext
    {
        /// <summary>
        /// Checks to see if a feature is enabled.
        /// </summary>
        /// <param name="feature">The feature.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="feature"/> is <see langword="null" />.</exception>
        /// <exception cref="Exceptions.FeatureStateNotFoundException">The given feature has no value assoicated with it.</exception>
        /// <returns><c>true</c> if the feature is enabled; otherwise, <c>false</c>.</returns>
        bool IsEnabled(IFeature feature);

        IFeatureTogglerSource TogglerSource { get; }
    }
}