using System.Collections.Generic;

namespace Toggled
{
    public interface IFeature
    {
        string Id { get; }
        string Description { get; }
        IEnumerable<IFeatureTrait> Traits { get; }
    }
}
