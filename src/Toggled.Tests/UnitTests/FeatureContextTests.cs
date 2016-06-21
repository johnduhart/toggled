using System;
using System.Linq;
using FakeItEasy;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit2;
using Toggled.Exceptions;
using Toggled.Tests.Helpers;
using Xunit;

namespace Toggled.Tests.UnitTests
{
    public class FeatureContextTests
    {
        [Fact]
        public void ConstructorThrowsWhenPassedNullFeatureToggleProvider()
        {
            Assert.Throws<ArgumentNullException>(() => new FeatureContext(null));
        }

        [Theory, ToggledAutoData]
        public void IsEnabledCallsGetsFeatureToggles([Frozen] IFeatureToggleProvider toggleProvider, IFeature feature,
            FeatureContext sut)
        {
            Ignore.Exception<FeatureStateNotFoundException, bool>(() => sut.IsEnabled(feature));

            A.CallTo(() => toggleProvider.GetFeatureToggles())
                .MustHaveHappened();
        }

        [Theory, ToggledAutoData]
        public void IsEnabledCallsIsEnabledOnToggle([Frozen] IFeatureToggleProvider toggleProvider, IFeature feature,
            IFeatureToggle featureToggle, bool expected, FeatureContext sut)
        {
            A.CallTo(() => featureToggle.IsEnabled(sut, feature))
                .Returns(expected);
            A.CallTo(() => toggleProvider.GetFeatureToggles())
                .Returns(new[] {featureToggle});

            bool result = sut.IsEnabled(feature);

            A.CallTo(() => featureToggle.IsEnabled(sut, feature))
                .MustHaveHappened();
            Assert.Equal(expected, result);
        }

        [Theory, ToggledAutoData]
        public void IsEnabledCallsAllToggles([Frozen] IFeatureToggleProvider toggleProvider, IFeature feature,
            Fixture fixture, FeatureContext sut)
        {
            var featureToggles = fixture.CreateMany<Fake<IFeatureToggle>>().ToList();
            foreach (Fake<IFeatureToggle> fake in featureToggles)
            {
                fake.CallsTo(ft => ft.IsEnabled(sut, feature))
                    .Returns(null);
            }
            var finalTogle = A.Fake<Fake<IFeatureToggle>>();
            finalTogle.CallsTo(ft => ft.IsEnabled(sut, feature))
                .Returns(true);
            featureToggles.Add(finalTogle);

            A.CallTo(() => toggleProvider.GetFeatureToggles())
                .Returns(featureToggles.Select(f => f.FakedObject));

            sut.IsEnabled(feature);

            foreach (Fake<IFeatureToggle> fake in featureToggles)
            {
                fake.CallsTo(ft => ft.IsEnabled(sut, feature))
                    .MustHaveHappened();
            }
        }

        [Theory, ToggledAutoData]
        public void IsEnabledUsesFirstToggleProviderResult([Frozen] IFeatureToggleProvider toggleProvider,
            IFeature feature, IFeatureToggle skippedToggle, IFeatureToggle enabledToggle, IFeatureToggle endToggle,
            bool expected, FeatureContext sut)
        {
            A.CallTo(() => enabledToggle.IsEnabled(sut, feature))
                .Returns(expected);
            A.CallTo(() => toggleProvider.GetFeatureToggles())
                .Returns(new[] {skippedToggle, enabledToggle, endToggle});

            bool result = sut.IsEnabled(feature);

            Assert.Equal(expected, result);
            A.CallTo(() => endToggle.IsEnabled(sut, feature))
                .MustNotHaveHappened();
        }

        [Theory, ToggledAutoData]
        public void IsEnabledThrowsWhenNoToggleProviderHasState(IFeature feature, FeatureContext sut)
        {
            var exception = Assert.Throws<FeatureStateNotFoundException>(() => sut.IsEnabled(feature));

            Assert.Same(feature, exception.Feature);
        }

        [Theory, ToggledAutoData]
        public void IsEnabledThrowsWhenGivenNullFeature(FeatureContext sut)
        {
            Assert.Throws<ArgumentNullException>(() => sut.IsEnabled(feature: null));
        }
    }
}