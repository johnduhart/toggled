using System.Collections.Generic;

namespace Toggled
{
    /// <summary>
    /// Provides <see cref="IFeatureToggler"/>s that are appropriate in
    /// the current environment.
    /// </summary>
    /// <remarks>
    /// Certain <see cref="IFeatureToggler"/>s may only be available during certain
    /// portions of an application's lifecycle (eg. a SqlFeatureToggleProvider).
    /// The <see cref="IFeatureTogglerSource"/> is evaluated for each feature.
    /// </remarks>
    public interface IFeatureTogglerSource
    {
        /// <summary>
        /// Returns <see cref="IFeatureToggler"/>s that are currently available.
        /// </summary>
        /// <returns>Feature togglers.</returns>
        IEnumerable<IFeatureToggler> GetFeatureToggles();
    }
}