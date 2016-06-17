using System;
using Xunit;

namespace Toggled.Tests
{
    public class FeatureTests
    {
        public class IsEnabled
        {
            [Fact]
            public void ThrowsExceptionOnNullFeature()
            {
                Assert.Throws<ArgumentNullException>(() => Feature.IsEnabled(null));
            }
        }
    }
}
