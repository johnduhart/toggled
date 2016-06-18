namespace Toggled
{
    public interface IFeatureToggle
    {
        bool? IsEnabled(IFeature feature);
    }
}