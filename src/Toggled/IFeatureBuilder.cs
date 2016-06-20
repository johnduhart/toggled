namespace Toggled
{
    /// <summary>
    /// Helper for building an <see cref="IFeature"/>.
    /// </summary>
    public interface IFeatureBuilder
    {
        /// <summary>
        /// Sets the description of the feature.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns>The current instance of <see cref="IFeatureBuilder"/></returns>
        IFeatureBuilder Description(string description);

        /// <summary>
        /// Adds the trait to the featrue
        /// </summary>
        /// <param name="trait">The trait</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="trait"/> is <see langword="null" />.</exception>
        /// <returns>The current instance of <see cref="IFeatureBuilder"/></returns>
        IFeatureBuilder WithTrait(IFeatureTrait trait);

        /// <summary>
        /// Builds the feature.
        /// </summary>
        /// <returns>A feature.</returns>
        IFeature Build();
    }
}