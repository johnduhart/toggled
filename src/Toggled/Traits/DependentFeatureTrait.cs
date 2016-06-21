using System;

namespace Toggled.Traits
{
    public class DependentFeatureTrait : IFeatureTrait
    {
        public DependentFeatureTrait(IFeature dependentFeature)
        {
            if (dependentFeature == null)
                throw new ArgumentNullException(nameof(dependentFeature));

            DependentFeature = dependentFeature;
        }

        public IFeature DependentFeature { get; }
    }
}