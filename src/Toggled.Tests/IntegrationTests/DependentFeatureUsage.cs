using Toggled.Toggles;
using Toggled.Traits;
using Xunit;

namespace Toggled.Tests.IntegrationTests
{
    public class DependentFeatureUsage
    {
        public readonly IFeature BaseFeature;
        public readonly IFeature ChildFeature;

        private readonly IFeatureContext _featureContext;

        public DependentFeatureUsage()
        {
            BaseFeature = FeatureBuilder.Create("BaseFeature")
                .Description("This is the base feature")
                .WithDefaultValue(false)
                .Build();

            ChildFeature = FeatureBuilder.Create("BaseFeature.Child")
                .Description("This is a child feature of the base feature, that should be disabled when the parent is.")
                .WithDefaultValue(true)
                .DependentOn(BaseFeature)
                .Build();

            _featureContext = new FeatureContext(new FeatureToggleProvider(new DependentFeatureToggle(), new DefaultValueToggle()));
        }

        [Fact]
        public void ChildFeatureShouldBeDisabled()
        {
            bool result = _featureContext.IsEnabled(ChildFeature);

            Assert.False(result);
        }
    }
}