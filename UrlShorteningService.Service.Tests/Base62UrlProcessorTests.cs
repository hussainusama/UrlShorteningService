using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using NSubstitute;
using UrlShorteningService.Model.DataContexts;
using UrlShorteningService.Model.Types;
using UrlShorteningService.Service.Encoders;
using UrlShorteningService.Service.Tests.Infrastructure;
using UrlShorteningService.Service.UrlProcessors;
using Xunit;

namespace UrlShorteningService.Service.Tests
{
    public class Base62UrlProcessorTests
    {
        [Theory, DefaultAutoData]
        public void DeflateAsync_ShortenUrl_ReturnsShortUrl(
            [Frozen] IUrlMappingsDataContext urlMapRepository,
            [Frozen] IBase62Encoder base62Encoder,
            UrlMapping mapping,
            string shortString,
            Base62UrlProcessor sut)
        {
            urlMapRepository.UrlMappings.Create().Returns(mapping);
            base62Encoder.Encode(mapping.Id).Returns(shortString);

            var result = Task.Run(async () => await sut.DeflateAsync(mapping.Url)).GetAwaiter().GetResult();

            result.Should().Be(shortString);
        }

        [Theory, DefaultAutoData]
        public void InflateAsync_LengthenUrl_ReturnsLongUrl(
            [Frozen] IUrlMappingsDataContext urlMapRepository,
            [Frozen] IBase62Encoder base62Encoder,
            UrlMapping mapping,
            string shortString,
            Base62UrlProcessor sut)
        {
            base62Encoder.Decode(shortString).Returns(mapping.Id);
            urlMapRepository.UrlMappings.GetByKeyAsync(mapping.Id).Returns(mapping);

            var result = Task.Run(async () => await sut.InflateAsync(shortString)).GetAwaiter().GetResult();

            result.Should().Be(mapping.Url);
        }
    }
}
