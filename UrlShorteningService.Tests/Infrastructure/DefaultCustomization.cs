using AutoFixture;
using AutoFixture.AutoNSubstitute;

namespace UrlShorteningService.Tests.Infrastructure
{
    internal class DefaultCustomization : CompositeCustomization
    {
        public DefaultCustomization() : base(
            new AutoNSubstituteCustomization {ConfigureMembers = true})
        {
        }
    }
}