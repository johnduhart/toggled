using AutoFixture.Xunit2;

namespace Toggled.Tests.Helpers
{
    public class ToggledInlineAutoDataAttribute : InlineAutoDataAttribute
    {
        public ToggledInlineAutoDataAttribute(params object[] values)
            : base(new ToggledAutoDataAttribute(), values)
        {
        }
    }
}