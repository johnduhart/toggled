namespace Toggled.Traits
{
    public class DefaultValueTrait : IFeatureTrait
    {
        public bool DefaultValue { get; }

        public DefaultValueTrait(bool defaultValue)
        {
            DefaultValue = defaultValue;
        }
    }
}