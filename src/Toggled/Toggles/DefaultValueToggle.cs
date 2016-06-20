using System;
using System.Linq;
using Toggled.Exceptions;
using Toggled.Traits;

namespace Toggled.Toggles
{
    public class DefaultValueToggle : IFeatureToggle
    {
        public bool? IsEnabled(IFeature feature)
        {
            if (feature == null)
                throw new ArgumentNullException(nameof(feature));

            DefaultValueTrait trait = null;

            foreach (DefaultValueTrait defaultValueTrait in feature.Traits.OfType<DefaultValueTrait>())
            {
                if (trait != null)
                    throw new InvalidFeatureException($"Feature {feature.Id} contains more than one {nameof(DefaultValueTrait)}");

                trait = defaultValueTrait;
            }

            return trait?.DefaultValue;
        }
    }
}