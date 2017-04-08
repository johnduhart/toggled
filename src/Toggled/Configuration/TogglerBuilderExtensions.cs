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

#if NET45
        public static ITogglerBuilder AppSettingsToggler(
            this ITogglerBuilder togglerBuilder)
        {
            return togglerBuilder.AddToggler(new AppSettingsToggler());
        }
#endif

        public static ITogglerBuilder DependentFeatureToggler(
            this ITogglerBuilder togglerBuilder)
        {
            return togglerBuilder.AddToggler(new DependentFeatureToggler());
        }
    }
}