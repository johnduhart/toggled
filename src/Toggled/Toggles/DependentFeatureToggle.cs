using System;
using System.Linq;
using Toggled.Traits;

namespace Toggled.Toggles
{
    public class DependentFeatureToggle : IFeatureToggle
    {
        public bool? IsEnabled(IFeatureContext featureContext, IFeature feature)
        {
            if (featureContext == null)
                throw new ArgumentNullException(nameof(featureContext));
            if (feature == null)
                throw new ArgumentNullException(nameof(feature));

            foreach (DependentFeatureTrait trait in feature.Traits.OfType<DependentFeatureTrait>())
            {
                if (!featureContext.IsEnabled(trait.DependentFeature))
                    return false;
            }

            return null;
        }
    }
}