using System;

namespace Toggled.Tests.Helpers
{
    public static class Ignore
    {
        public static TReturn Exception<TException, TReturn>(Func<TReturn> func)
            where TException : Exception
        {
            try
            {
                return func();
            }
            catch (TException)
            {
                return default(TReturn);
            }
        }

        public static T AllExceptions<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch
            {
                return default(T);
            }
        }
    }
}