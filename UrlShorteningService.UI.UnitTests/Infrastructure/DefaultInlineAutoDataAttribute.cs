using AutoFixture.Xunit2;

namespace UrlShorteningService.UI.UnitTests.Infrastructure
{
    public class DefaultInlineAutoDataAttribute : InlineAutoDataAttribute
    {
        public DefaultInlineAutoDataAttribute(params object[] args) : base(new DefaultAutoDataAttribute(), args)
        {
        }
    }
}