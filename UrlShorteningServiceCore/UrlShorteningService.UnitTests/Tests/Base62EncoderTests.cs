using FluentAssertions;
using UrlShorteningService.Encoders;
using UrlShorteningService.Service.Tests.Infrastructure;
using Xunit;

namespace UrlShorteningService.UnitTests.Tests
{
    public class Base62EncoderTests
    {
        [Theory]
        [DefaultInlineAutoData(1234568, "5BAO")]
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
            var encoded = sut.Encode(identity);
                
            encoded.Should().Be(shortString);
        }

        [Theory]
        [DefaultInlineAutoData("5BAO", 1234568)]
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
            var decoded = sut.Decode(shortString);
                
            decoded.Should().Be(identity);
        }
    }
}
