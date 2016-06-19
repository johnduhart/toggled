namespace Toggled
{
    public interface IFeatureBuilder
    {
        IFeature Build();
        IFeatureBuilder Description(string description);
        IFeatureBuilder WithTrait(IFeatureTrait trait);
    }
}