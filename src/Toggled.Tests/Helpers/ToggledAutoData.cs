using AutoFixture;
using AutoFixture.AutoFakeItEasy;
using AutoFixture.Xunit2;

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