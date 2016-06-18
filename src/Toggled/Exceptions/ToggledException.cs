using System;

namespace Toggled.Exceptions
{
    public class ToggledException : Exception
    {
        public ToggledException(string message) : base(message)
        {
        }
    }
}