using System.Collections.Generic;

namespace Toggled
{
    /// <summary>
    /// Provides <see cref="IFeatureToggle"/>s that are appropriate in
    /// the current environment.
    /// </summary>
    /// <remarks>
    /// Certain <see cref="IFeatureToggle"/>s may only be available during certain
    /// portions of an application's lifecycle (eg. a SqlFeatureToggleProvider).
    /// The <see cref="IFeatureToggleProvider"/> is evaluated for each feature.
    /// </remarks>
    public interface IFeatureToggleProvider
    {
        /// <summary>
        /// Returns <see cref="IFeatureToggle"/>s that are currently available.
        /// </summary>
        /// <returns>Feature toggles.</returns>
        IEnumerable<IFeatureToggle> GetFeatureToggles();
    }
}