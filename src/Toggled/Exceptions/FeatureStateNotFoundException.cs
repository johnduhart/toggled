namespace Toggled.Exceptions
{
    public class FeatureStateNotFoundException : ToggledException
    {
        public IFeature Feature { get; }

        public FeatureStateNotFoundException(IFeature feature)
            : base($"Could not find a toggle state for feature {feature.Id}")
        {
            Feature = feature;
        }
    }
}