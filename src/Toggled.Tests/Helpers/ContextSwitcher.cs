using System;
using System.Threading;

namespace Toggled.Tests.Helpers
{
    public class ContextSwitcher : IDisposable
    {
        private readonly IFeatureContext _previousContext;

        private ContextSwitcher(IFeatureContext context)
        {
            _previousContext = Interlocked.Exchange(ref Feature.Context, context);
        }

        public static IDisposable For(IFeatureContext context)
        {
            return new ContextSwitcher(context);
        }

        public void Dispose()
        {
            Feature.Context = _previousContext;
        }
    }
}