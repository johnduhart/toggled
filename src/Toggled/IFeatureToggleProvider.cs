using System.Collections.Generic;

namespace Toggled
{
    public interface IFeatureToggleProvider
    {
        IEnumerable<IFeatureToggle> GetFeatureToggles();
    }
}