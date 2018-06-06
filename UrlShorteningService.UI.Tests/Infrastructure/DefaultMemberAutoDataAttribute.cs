using AutoFixture.Xunit2;
using Xunit;

namespace UrlShorteningService.UI.Tests.Infrastructure
{
    public class DefaultMemberAutoDataAttribute : CompositeDataAttribute
    {
        public DefaultMemberAutoDataAttribute(string memberName)
            : base(
                new MemberDataAttribute(memberName), new DefaultAutoDataAttribute(memberName))
        {
        }
    }
}