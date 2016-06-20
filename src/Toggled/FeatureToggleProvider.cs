using System;
using System.Collections.Generic;

namespace Toggled
{
    /// <summary>
    /// An implementation of <see cref="IFeatureToggleProvider"/> that returns the same
    /// <see cref="IFeatureToggle"/>s each time.
    /// </summary>
    public class FeatureToggleProvider : IFeatureToggleProvider
    {
        private readonly IFeatureToggle[] _featureToggles;

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureToggleProvider"/> class.
        /// </summary>
        /// <param name="featureToggles"></param>
        public FeatureToggleProvider(params IFeatureToggle[] featureToggles)
        {
            if (featureToggles == null)
                throw new ArgumentNullException(nameof(featureToggles));
            if (featureToggles.Length == 0)
                throw new ArgumentException("featureToggles be an empty array.", nameof(featureToggles));

            _featureToggles = featureToggles;
        }

        public IEnumerable<IFeatureToggle> GetFeatureToggles()
        {
            return _featureToggles;
        }
    }
}