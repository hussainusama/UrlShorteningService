using FluentAssertions;
using UrlShorteningService.Service.Tests.Infrastructure;
using UrlShorteningService.Service.Encoders;
using Xunit;

namespace UrlShorteningService.Tests
{
    public class Base62EncoderTests
    {
        [Theory]
        [DefaultInlineAutoData(1234567, "5BAN")]
        [DefaultInlineAutoData(123456, "W7E")]
        [DefaultInlineAutoData(12345, "3D7")]
        [DefaultInlineAutoData(1234, "Ju")]
        [DefaultInlineAutoData(123, "1z")]
        [DefaultInlineAutoData(12, "C")]
        [DefaultInlineAutoData(1, "1")]
        public void Encode_EncodeNumberToString_ReturnsEncodedString(
            int identity,
            string shortString,
            Base62Encoder sut)
        {
            sut.Encode(identity).Should().Be(shortString);
        }

        [Theory]
        [DefaultInlineAutoData("5BAN", 1234567)]
        [DefaultInlineAutoData("W7E", 123456)]
        [DefaultInlineAutoData("3D7", 12345)]
        [DefaultInlineAutoData("Ju", 1234)]
        [DefaultInlineAutoData("1z", 123)]
        [DefaultInlineAutoData("C", 12)]
        [DefaultInlineAutoData("1", 1)]
        public void Decode_DecodeStringToNumber_ReturnsDecodedNumber(
            string shortString,
            int identity,
            Base62Encoder sut)
        {
            sut.Decode(shortString).Should().Be(identity);
        }
    }
}
