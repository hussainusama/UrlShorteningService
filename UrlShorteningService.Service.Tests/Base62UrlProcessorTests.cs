using System.Threading.Tasks;
using AutoFixture.Xunit2;
using NSubstitute;
using UrlShorteningService.Service.Repositories;
using UrlShorteningService.Service.Tests.Infrastructure;
using UrlShorteningService.Service.UrlProcessors;
using UrlShorteningService.Service.Encoders;
using Xunit;
using FluentAssertions;

namespace UrlShorteningService.Tests
{
    public class Base62UrlProcessorTests
    {
        [Theory, DefaultAutoData]
        public void DeflateAsync_LongUrlStoredInRepo_ReturnsShortUrl(
            [Frozen] IUrlMapRepository urlMapRepository,
            [Frozen] IBase62Encoder base62Encoder,
            string longUrl,
            int identity,
            string shortString,
            Base62UrlProcessor sut)
        {
            urlMapRepository.InsertAsync(longUrl).Returns(identity);
            base62Encoder.Encode(identity).Returns(shortString);

            var result = Task.Run(async () => await sut.DeflateAsync(longUrl)).GetAwaiter().GetResult();

            result.Should().Be(shortString);
        }

        [Theory, DefaultAutoData]
        public void InflateAsync_LongUrlStoredInRepo_ReturnsLongUrl(
            [Frozen] IUrlMapRepository urlMapRepository,
            [Frozen] IBase62Encoder base62Encoder,
            string longUrl,
            int identity,
            string shortString,
            Base62UrlProcessor sut)
        {
            base62Encoder.Decode(shortString).Returns(identity);
            urlMapRepository.GetByIdAsync(identity).Returns(longUrl);

            var result = Task.Run(async () => await sut.InflateAsync(shortString)).GetAwaiter().GetResult();

            result.Should().Be(longUrl);
        }
    }
}
