namespace Toggled.Traits
{
    /// <summary>
    /// Describes a default value that the feature should have.
    /// </summary>
    public class DefaultValueTrait : IFeatureTrait
    {
        /// <summary>
        /// Gets the default value
        /// </summary>
        public bool DefaultValue { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultValueTrait"/> class.
        /// </summary>
        /// <param name="defaultValue">The default value.</param>
        public DefaultValueTrait(bool defaultValue)
        {
            DefaultValue = defaultValue;
        }
    }
}