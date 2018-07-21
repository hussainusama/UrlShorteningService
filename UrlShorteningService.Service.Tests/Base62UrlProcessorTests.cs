using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using NSubstitute;
using UrlShorteningService.Model.Factories;
using UrlShorteningService.Model.Types;
using UrlShorteningService.Model.UnitsOfWork;
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
            [Frozen] IUnitOfWorkFactory unitOfWorkFactory,
            [Frozen] IUnitOfWork unitOfWork,
            [Frozen] IBase62Encoder base62Encoder,
            [Frozen] UrlMapping mapping,
            [Frozen] string shortString,
            Base62UrlProcessor sut)
        {
            unitOfWorkFactory.Create().Returns(unitOfWork);
            unitOfWork.UrlMappingsRepository.Create().Returns(mapping);
            base62Encoder.Encode(mapping.Id).Returns(shortString);

            var result = Task.Run(async () => await sut.DeflateAsync(mapping.Url)).GetAwaiter().GetResult();

            result.Should().Be(shortString);
        }

        [Theory, DefaultAutoData]
        public void InflateAsync_LengthenUrl_ReturnsLongUrl(
            [Frozen] IUnitOfWorkFactory unitOfWorkFactory,
            [Frozen] IUnitOfWork unitOfWork,
            [Frozen] IBase62Encoder base62Encoder,
            [Frozen] UrlMapping mapping,
            [Frozen] string shortString,
            Base62UrlProcessor sut)
        {
            unitOfWorkFactory.Create().Returns(unitOfWork);
            base62Encoder.Decode(shortString).Returns(mapping.Id);
            unitOfWork.UrlMappingsRepository.GetByKeyAsync(mapping.Id).Returns(mapping);

            var result = Task.Run(async () => await sut.InflateAsync(shortString)).GetAwaiter().GetResult();

            result.Should().Be(mapping.Url);
        }
    }
}
