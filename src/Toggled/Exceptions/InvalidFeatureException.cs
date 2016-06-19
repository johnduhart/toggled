namespace Toggled.Exceptions
{
    public class InvalidFeatureException : ToggledException
    {
        public InvalidFeatureException(string message) : base(message)
        {
        }
    }
}