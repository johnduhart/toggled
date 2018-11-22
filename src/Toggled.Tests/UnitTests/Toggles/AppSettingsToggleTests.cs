#if NET462
using System;
using AutoFixture;
using Toggled.Tests.Fixtures;
using Toggled.Tests.Helpers;
using Toggled.Togglers;
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
        public void ReturnsAppSettingValueWhenSet(string value, bool? expected, FeatureFixture feature, Fixture fixture, AppSettingsToggler sut)
        {
            // Apparently AutoFixture will reuse the feature
            feature.Id = fixture.Create<string>();

            using (AppSetting.Use($"{AppSettingsToggler.SettingsPrefix}{feature.Id}", value))
            {
                bool? result = sut.IsEnabled(null, feature);

                Assert.Equal(expected, result);
            }
        }

        [Theory, ToggledAutoData]
        public void ReturnsNullWhenNoValueExists(FeatureFixture feature, Fixture fixture, AppSettingsToggler sut)
        {
            feature.Id = fixture.Create<string>();

            bool? result = sut.IsEnabled(null, feature);

            Assert.Equal(null, result);
        }

        [Theory, ToggledAutoData]
        public void ThrowsExceptionWhenGivenNullFeature(AppSettingsToggler sut)
        {
            Assert.Throws<ArgumentNullException>(() => sut.IsEnabled(null, null));
        }
    }
}
#endif
