using System.Collections.Generic;

namespace Toggled
{
    /// <summary>
    /// Represents a Feature that can be enabled or disabled.
    /// </summary>
    public interface IFeature
    {
        /// <summary>
        /// Gets the unquie ID of the Feature
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets the description of the feature
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets all traits assoicated with the feature
        /// </summary>
        IEnumerable<IFeatureTrait> Traits { get; }
    }
}
