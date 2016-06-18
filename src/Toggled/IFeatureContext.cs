namespace Toggled
{
    public interface IFeatureContext
    {
        bool IsEnabled(IFeature feature);
    }
}