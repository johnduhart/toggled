using System;
using Toggled.Exceptions;

namespace Toggled
{
    public static class Feature
    {
        public static IFeatureContext Context;

        public static bool IsEnabled(IFeature feature)
        {
            if (feature == null)
                throw new ArgumentNullException(nameof(feature));

            if (Context == null)
                throw new MissingFeatureContextException();

            return Context.IsEnabled(feature);
        }
    }
}