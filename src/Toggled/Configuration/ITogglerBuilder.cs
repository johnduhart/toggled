namespace Toggled.Configuration
{
    public interface ITogglerBuilder
    {
        ITogglerBuilder AddToggler(IFeatureToggler featureToggler);
        FeatureContextBuilder End();
    }
}