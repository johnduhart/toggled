using Toggled.Tests.Helpers;
using Toggled.Togglers;
using Toggled.Traits;
using Xunit;

namespace Toggled.Tests.IntegrationTests
{
    public class BasicUsage
    {
        private readonly IFeature _testFeature = FeatureBuilder.Create("MyTestingFeature")
            .Description("This is my basic test feature")
            .WithDefaultValue(true)
            .Build();

        private readonly IFeatureContext _featureContext;

        public BasicUsage()
        {
            _featureContext = new FeatureContext(new FeatureTogglerSource(new DefaultValueToggler()));
        }

        [Fact]
        public void FeatureContextHasDefaultValue()
        {
            Assert.True(_featureContext.IsEnabled(_testFeature));
        }

        [Fact]
        public void FeatureHasDefaultValue()
        {
            using (ContextSwitcher.For(_featureContext))
            {
                Assert.True(Feature.IsEnabled(_testFeature));
            }
        }
    }
}