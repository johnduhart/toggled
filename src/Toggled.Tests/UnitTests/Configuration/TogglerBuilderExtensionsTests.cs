using System.Diagnostics.CodeAnalysis;
using FakeItEasy;
using Toggled.Configuration;
using Toggled.Tests.Helpers;
using Toggled.Togglers;
using Xunit;

namespace Toggled.Tests.UnitTests.Configuration
{
    [SuppressMessage("ReSharper", "InvokeAsExtensionMethod")]
    public class TogglerBuilderExtensionsTests
    {
        [Theory, ToggledAutoData]
        public void DefaultValueTogglerAddsToggler(ITogglerBuilder togglerBuilder)
        {
            A.CallTo(() => togglerBuilder.AddToggler(A<IFeatureToggler>._))
                .Returns(togglerBuilder);

            ITogglerBuilder result =
                TogglerBuilderExtensions.DefaultValueToggler(togglerBuilder);

            Assert.Same(togglerBuilder, result);
            A.CallTo(() => togglerBuilder.AddToggler(A<DefaultValueToggler>._))
                .MustHaveHappened();
        }

        [Theory, ToggledAutoData]
        public void AppSettingsTogglerAddsToggler(ITogglerBuilder togglerBuilder)
        {
            A.CallTo(() => togglerBuilder.AddToggler(A<IFeatureToggler>._))
                .Returns(togglerBuilder);

            ITogglerBuilder result =
                TogglerBuilderExtensions.AppSettingsToggler(togglerBuilder);

            Assert.Same(togglerBuilder, result);
            A.CallTo(() => togglerBuilder.AddToggler(A<AppSettingsToggler>._))
                .MustHaveHappened();
        }

        [Theory, ToggledAutoData]
        public void DependentFeatureTogglerAddsToggler(ITogglerBuilder togglerBuilder)
        {
            A.CallTo(() => togglerBuilder.AddToggler(A<IFeatureToggler>._))
                .Returns(togglerBuilder);

            ITogglerBuilder result =
                TogglerBuilderExtensions.DependentFeatureToggler(togglerBuilder);

            Assert.Same(togglerBuilder, result);
            A.CallTo(() => togglerBuilder.AddToggler(A<DependentFeatureToggler>._))
                .MustHaveHappened();
        }
    }
}