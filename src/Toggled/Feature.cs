using System;

namespace Toggled
{
    public static class Feature
    {
        public static bool IsEnabled(IFeature feature)
        {
            if (feature == null)
                throw new ArgumentNullException(nameof(feature));

            throw new NotImplementedException();
        }
    }
}