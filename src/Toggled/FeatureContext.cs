using System;
using Toggled.Exceptions;

namespace Toggled
{
    public class FeatureContext : IFeatureContext
    {
        private readonly IFeatureTogglerSource _togglerSource;

        public FeatureContext(IFeatureTogglerSource togglerSource)
        {
            if (togglerSource == null)
                throw new ArgumentNullException(nameof(togglerSource));

            _togglerSource = togglerSource;
        }

        public bool IsEnabled(IFeature feature)
        {
            if (feature == null)
                throw new ArgumentNullException(nameof(feature));

            foreach (IFeatureToggler toggle in _togglerSource.GetFeatureToggles())
            {
                bool? result = toggle.IsEnabled(this, feature);
                if (result.HasValue)
                    return result.Value;
            }

            throw new FeatureStateNotFoundException(feature);
        }
    }
}