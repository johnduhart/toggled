using System;
using Toggled.Exceptions;

namespace Toggled
{
    public class FeatureContext : IFeatureContext
    {
        private readonly IFeatureToggleProvider _toggleProvider;

        public FeatureContext(IFeatureToggleProvider toggleProvider)
        {
            if (toggleProvider == null)
                throw new ArgumentNullException(nameof(toggleProvider));

            _toggleProvider = toggleProvider;
        }

        public bool IsEnabled(IFeature feature)
        {
            if (feature == null)
                throw new ArgumentNullException(nameof(feature));

            foreach (IFeatureToggle toggle in _toggleProvider.GetFeatureToggles())
            {
                bool? result = toggle.IsEnabled(feature);
                if (result.HasValue)
                    return result.Value;
            }

            throw new FeatureStateNotFoundException(feature);
        }
    }
}