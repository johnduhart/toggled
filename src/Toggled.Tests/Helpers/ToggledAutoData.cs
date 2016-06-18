using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoFakeItEasy;
using Ploeh.AutoFixture.Xunit2;

namespace Toggled.Tests.Helpers
{
    public class ToggledAutoDataAttribute : AutoDataAttribute
    {
        public ToggledAutoDataAttribute()
            : base(new Fixture().Customize(new AutoFakeItEasyCustomization()))
        {
        }
    }
}