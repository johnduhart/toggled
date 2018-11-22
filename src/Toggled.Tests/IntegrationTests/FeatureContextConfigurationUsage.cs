using System.Collections.Generic;
using Toggled.Configuration;
using Toggled.Togglers;
using Xunit;

namespace Toggled.Tests.IntegrationTests
{
    public class FeatureContextConfigurationUsage
    {
        private readonly IFeatureContext _featureContext;

        public FeatureContextConfigurationUsage()
        {
            _featureContext = new FeatureContextBuilder()
                .Togglers
                    .DependentFeatureToggler()
#if NET462
                    .AppSettingsToggler()
#endif
                    .DefaultValueToggler()
                    .End()
                .GetContext();
        }

        [Fact]
        public void ContextHasTogglers()
        {
            IEnumerable<IFeatureToggler> togglers = _featureContext.TogglerSource.GetFeatureToggles();

            Assert.Collection(togglers, 
                toggler => Assert.IsType<DependentFeatureToggler>(toggler),
#if NET462
                toggler => Assert.IsType<AppSettingsToggler>(toggler),
#endif
                toggler => Assert.IsType<DefaultValueToggler>(toggler));
        }
    }
}