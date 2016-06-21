using System;
using Ploeh.AutoFixture;
using Toggled.Tests.Fixtures;
using Toggled.Tests.Helpers;
using Toggled.Toggles;
using Xunit;

namespace Toggled.Tests.UnitTests.Toggles
{
    public class AppSettingsToggleTests
    {
        [Theory]
        [ToggledInlineAutoData("true", true)]
        [ToggledInlineAutoData("True", true)]
        [ToggledInlineAutoData("TRUE", true)]
        [ToggledInlineAutoData("false", false)]
        [ToggledInlineAutoData("False", false)]
        [ToggledInlineAutoData("on", null)]
        [ToggledInlineAutoData("1", null)]
        public void ReturnsAppSettingValueWhenSet(string value, bool? expected, FeatureFixture feature, Fixture fixture, AppSettingsToggle sut)
        {
            // Apparently AutoFixture will reuse the feature
            feature.Id = fixture.Create<string>();

            using (AppSetting.Use($"{AppSettingsToggle.SettingsPrefix}{feature.Id}", value))
            {
                bool? result = sut.IsEnabled(null, feature);

                Assert.Equal(expected, result);
            }
        }

        [Theory, ToggledAutoData]
        public void ReturnsNullWhenNoValueExists(FeatureFixture feature, Fixture fixture, AppSettingsToggle sut)
        {
            feature.Id = fixture.Create<string>();

            bool? result = sut.IsEnabled(null, feature);

            Assert.Equal(null, result);
        }

        [Theory, ToggledAutoData]
        public void ThrowsExceptionWhenGivenNullFeature(AppSettingsToggle sut)
        {
            Assert.Throws<ArgumentNullException>(() => sut.IsEnabled(null, null));
        }
    }
}