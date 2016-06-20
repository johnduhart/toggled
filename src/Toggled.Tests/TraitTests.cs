using Toggled.Tests.Helpers;
using Toggled.Traits;
using Xunit;

namespace Toggled.Tests
{
    public class TraitTests
    {
        [Theory, ToggledAutoData]
        public void DefaultValueTraitConstructorSetsDefaultValue(bool defaultValue)
        {
            var sut = new DefaultValueTrait(defaultValue);

            Assert.Equal(defaultValue, sut.DefaultValue);
        }
    }
}