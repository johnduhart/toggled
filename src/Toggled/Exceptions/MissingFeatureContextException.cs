namespace Toggled.Exceptions
{
    public class MissingFeatureContextException : ToggledException
    {
        public MissingFeatureContextException()
            : base("Attempted to use a Feature method without having the Feature.Context set")
        {
        }
    }
}