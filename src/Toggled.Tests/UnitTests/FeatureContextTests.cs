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
        public void IsEnabledCallsGetsFeatureToggles([Frozen] IFeatureTogglerSource togglerSource, IFeature feature,
            FeatureContext sut)
        {
            Ignore.Exception<FeatureStateNotFoundException, bool>(() => sut.IsEnabled(feature));

            A.CallTo(() => togglerSource.GetFeatureToggles())
                .MustHaveHappened();
        }

        [Theory, ToggledAutoData]
        public void IsEnabledCallsIsEnabledOnToggle([Frozen] IFeatureTogglerSource togglerSource, IFeature feature,
            IFeatureToggler featureToggler, bool expected, FeatureContext sut)
        {
            A.CallTo(() => featureToggler.IsEnabled(sut, feature))
                .Returns(expected);
            A.CallTo(() => togglerSource.GetFeatureToggles())
                .Returns(new[] {featureToggler});

            bool result = sut.IsEnabled(feature);

            A.CallTo(() => featureToggler.IsEnabled(sut, feature))
                .MustHaveHappened();
            Assert.Equal(expected, result);
        }

        [Theory, ToggledAutoData]
        public void IsEnabledCallsAllToggles([Frozen] IFeatureTogglerSource togglerSource, IFeature feature,
            Fixture fixture, FeatureContext sut)
        {
            var featureToggles = fixture.CreateMany<Fake<IFeatureToggler>>().ToList();
            foreach (Fake<IFeatureToggler> fake in featureToggles)
            {
                fake.CallsTo(ft => ft.IsEnabled(sut, feature))
                    .Returns(null);
            }
            var finalTogle = A.Fake<Fake<IFeatureToggler>>();
            finalTogle.CallsTo(ft => ft.IsEnabled(sut, feature))
                .Returns(true);
            featureToggles.Add(finalTogle);

            A.CallTo(() => togglerSource.GetFeatureToggles())
                .Returns(featureToggles.Select(f => f.FakedObject));

            sut.IsEnabled(feature);

            foreach (Fake<IFeatureToggler> fake in featureToggles)
            {
                fake.CallsTo(ft => ft.IsEnabled(sut, feature))
                    .MustHaveHappened();
            }
        }

        [Theory, ToggledAutoData]
        public void IsEnabledUsesFirstToggleProviderResult([Frozen] IFeatureTogglerSource togglerSource,
            IFeature feature, IFeatureToggler skippedToggler, IFeatureToggler enabledToggler, IFeatureToggler endToggler,
            bool expected, FeatureContext sut)
        {
            A.CallTo(() => enabledToggler.IsEnabled(sut, feature))
                .Returns(expected);
            A.CallTo(() => togglerSource.GetFeatureToggles())
                .Returns(new[] {skippedToggler, enabledToggler, endToggler});

            bool result = sut.IsEnabled(feature);

            Assert.Equal(expected, result);
            A.CallTo(() => endToggler.IsEnabled(sut, feature))
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