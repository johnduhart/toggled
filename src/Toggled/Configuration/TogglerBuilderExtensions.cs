using Toggled.Togglers;

namespace Toggled.Configuration
{
    public static class TogglerBuilderExtensions
    {
        public static ITogglerBuilder DefaultValueToggler(
            this ITogglerBuilder togglerBuilder)
        {
            return togglerBuilder.AddToggler(new DefaultValueToggler());
        }

        public static ITogglerBuilder AppSettingsToggler(
            this ITogglerBuilder togglerBuilder)
        {
            return togglerBuilder.AddToggler(new AppSettingsToggler());
        }

        public static ITogglerBuilder DependentFeatureToggler(
            this ITogglerBuilder togglerBuilder)
        {
            return togglerBuilder.AddToggler(new DependentFeatureToggler());
        }
    }
}