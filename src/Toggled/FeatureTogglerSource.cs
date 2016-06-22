using System;
using System.Collections.Generic;

namespace Toggled
{
    /// <summary>
    /// An implementation of <see cref="IFeatureTogglerSource"/> that returns the same
    /// <see cref="IFeatureToggler"/>s each time.
    /// </summary>
    public class FeatureTogglerSource : IFeatureTogglerSource
    {
        private readonly IFeatureToggler[] _featureTogglers;

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureTogglerSource"/> class.
        /// </summary>
        /// <param name="featureTogglers"></param>
        public FeatureTogglerSource(params IFeatureToggler[] featureTogglers)
        {
            if (featureTogglers == null)
                throw new ArgumentNullException(nameof(featureTogglers));
            if (featureTogglers.Length == 0)
                throw new ArgumentException("featureToggles cannot be an empty array.", nameof(featureTogglers));

            _featureTogglers = featureTogglers;
        }

        public IEnumerable<IFeatureToggler> GetFeatureToggles()
        {
            return _featureTogglers;
        }
    }
}