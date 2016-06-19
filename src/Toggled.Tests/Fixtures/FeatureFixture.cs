using System.Collections.Generic;

namespace Toggled.Tests.Fixtures
{
    public class FeatureFixture : IFeature
    {
        public FeatureFixture()
        {
            Traits = new List<IFeatureTrait>();
        }

        public string Id { get; set; }
        public string Description { get; set; }
        public List<IFeatureTrait> Traits { get; set; }
        IEnumerable<IFeatureTrait> IFeature.Traits => Traits;
    }
}