using AutoFixture.Xunit2;

namespace UrlShorteningService.Service.Tests.Infrastructure
{
    public class DefaultInlineAutoDataAttribute : InlineAutoDataAttribute
    {
        public DefaultInlineAutoDataAttribute(params object[] args) : base(new DefaultAutoDataAttribute(), args)
        {
        }
    }
}