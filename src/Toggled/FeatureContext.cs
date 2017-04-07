using System;
using Toggled.Exceptions;

namespace Toggled
{
    public class FeatureContext : IFeatureContext
    {
        public FeatureContext(IFeatureTogglerSource togglerSource)
        {
            if (togglerSource == null)
                throw new ArgumentNullException(nameof(togglerSource));

            TogglerSource = togglerSource;
        }

        public IFeatureTogglerSource TogglerSource { get; }

        public bool IsEnabled(IFeature feature)
        {
            if (feature == null)
                throw new ArgumentNullException(nameof(feature));

            foreach (IFeatureToggler toggle in TogglerSource.GetFeatureToggles())
            {
                bool? result = toggle.IsEnabled(this, feature);
                if (result.HasValue)
                    return result.Value;
            }

            throw new FeatureStateNotFoundException(feature);
        }
    }
}