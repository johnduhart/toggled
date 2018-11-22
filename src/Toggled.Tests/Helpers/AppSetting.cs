#if NET462
using System;
using System.Configuration;

namespace Toggled.Tests.Helpers
{
    public class AppSetting : IDisposable
    {
        private readonly string _key;
        private bool _disposed;

        private AppSetting(string key, string value)
        {
            if (ConfigurationManager.AppSettings.Get(key) != null)
                throw new InvalidOperationException(
                    $"AppSetting {key} is already set, {nameof(AppSetting)} will not overwrite it");

            ConfigurationManager.AppSettings.Set(key, value);
            _key = key;
        }

        public static IDisposable Use(string key, string value)
        {
            return new AppSetting(key, value);
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            _disposed = true;
            //ConfigurationManager.AppSettings.Remove(_key);
        }
    }
}
#endif
