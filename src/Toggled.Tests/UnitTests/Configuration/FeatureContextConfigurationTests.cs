using System.Linq;
using Toggled.Configuration;
using Toggled.Tests.Helpers;
using Xunit;

namespace Toggled.Tests.UnitTests.Configuration
{
    public class FeatureContextConfigurationTests
    {
        [Theory, ToggledAutoData]
        public void AddsTogglerToFeatureContext(FeatureContextBuilder sut, IFeatureToggler featureToggler)
        {
            IFeatureContext context = sut.WithToggler(featureToggler)
                .GetContext();

            Assert.Same(featureToggler, context.TogglerSource.GetFeatureToggles().Single());
        }

        [Theory, ToggledAutoData]
        public void AddsTogglersToFeatureContext(FeatureContextBuilder sut, IFeatureToggler[] togglers)
        {
            IFeatureContext context = sut.WithTogglers(togglers)
                .GetContext();

            Assert.Equal(togglers, context.TogglerSource.GetFeatureToggles());
        }

        [Theory, ToggledAutoData]
        public void AddsTogglersUsingAdderToFeatureContext(FeatureContextBuilder sut,
            IFeatureToggler featureToggler)
        {
            IFeatureContext context = sut.Togglers
                    .AddToggler(featureToggler)
                    .End()
                .GetContext();

            Assert.Same(featureToggler, context.TogglerSource.GetFeatureToggles().Single());
        }
    }
}