#if NET45
using System;
using System.Configuration;

namespace Toggled.Togglers
{
    public class AppSettingsToggler : IFeatureToggler
    {
        public const string SettingsPrefix = "Feature:";

        public bool? IsEnabled(IFeatureContext featureContext, IFeature feature)
        {
            if (feature == null)
                throw new ArgumentNullException(nameof(feature));

            string configName = SettingsPrefix + feature.Id;
            string configValue = ConfigurationManager.AppSettings[configName];

            bool result;
            if (bool.TryParse(configValue, out result))
            {
                return result;
            }

            return null;
        }
    }
}
#endif