using System;

namespace Toggled
{
    public static class FeatureContextExtensions
    {
        public static bool IsDisabled(this IFeatureContext featureContext, IFeature feature)
        {
            if (featureContext == null)
                throw new ArgumentNullException(nameof(featureContext));
            if (feature == null)
                throw new ArgumentNullException(nameof(feature));

            return !featureContext.IsEnabled(feature);
        }
    }
}