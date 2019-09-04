using System;
using System.Net;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using UrlShorteningService.Contexts;
using UrlShorteningService.Controllers;
using UrlShorteningService.DTO;
using UrlShorteningService.Encoders;
using UrlShorteningService.Models;
using UrlShorteningService.Repositories;
using UrlShorteningService.Service.Tests.Infrastructure;
using UrlShorteningService.Texts;
using Xunit;

namespace UrlShorteningService.UnitTests.Tests
{
    public class UrlControllerTests
    {
        [Theory, DefaultAutoData]
        public void GetEncodedUrl_AddsUrlToDb_ReturnsOkResponseWithEncodedStringForNextDbId(
           [Frozen]IRepository<UrlMap, int> repository,
           [Frozen]IBase62Encoder encoder,
           [Frozen]IUrlMapContext context,
           UrlDto urlDto,
           [Frozen]UrlMap urlmap,
           string shortUrl,
           UrlController sut)
        {
            urlDto.LongUrl = "http://www.google.com";
            context.UrlMaps.Returns(repository);
            repository.Create().Returns(urlmap);
            context.When(x => x.SaveChangesAsync()).Do(x => urlmap.Id = 2109);
            encoder.Encode(2109).Returns(shortUrl);

            var actionResult = Task.Run(async () => await sut.GetEncodedUrl(urlDto)).GetAwaiter().GetResult();

            actionResult.Should().BeOfType<ObjectResult>().Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
            actionResult.Value.Should().Be(shortUrl);
        }

        [Theory, DefaultAutoData]
        public void GetEncodedUrl_InvalidUrl_ReturnsBadRequestResponseWithMessage(
            UrlDto urlDto,
            UrlController sut)
        {
            urlDto.LongUrl = "invalid";

            var actionResult = Task.Run(async () => await sut.GetEncodedUrl(urlDto)).GetAwaiter().GetResult();

            actionResult.Should().BeOfType<ObjectResult>().Which.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            actionResult.Value.Should().Be(ResponseMessages.InvalidUrl);
        }

        [Theory, DefaultAutoData]
        public void GetEncodedUrl_ExceptionOccured_ReturnsInternalServerErrorResponseWithException(
            [Frozen]IUrlMapContext context,
            UrlDto urlDto,
            Exception ex,
            UrlController sut)
        {
            urlDto.LongUrl = "http://www.google.com";
            context.SaveChangesAsync().Throws(ex);

            var actionResult = Task.Run(async () => await sut.GetEncodedUrl(urlDto)).GetAwaiter().GetResult();

            actionResult.Should().BeOfType<ObjectResult>().Which.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError);
            actionResult.Value.Should().Be(ex.ToString());
        }

        [Theory, DefaultAutoData]
        public void GetOriginalUrl_DecodesStringToDbId_ReturnsOkResponseWithUrlForDbId(
            [Frozen]IRepository<UrlMap, int> repository,
            [Frozen]IBase62Encoder encoder,
            [Frozen]IUrlMapContext context,
            UrlMap urlmap,
            int dbId,
            string shortUrl,
            UrlController sut)
        {
            encoder.Decode(shortUrl).Returns(dbId);
            context.UrlMaps.Returns(repository);
            repository.FindAsync(dbId).Returns(urlmap);

            var actionResult = Task.Run(async () => await sut.GetOriginalUrl(shortUrl)).GetAwaiter().GetResult();

            actionResult.Should().BeOfType<ObjectResult>().Which.StatusCode.Should().Be((int)HttpStatusCode.OK);
            actionResult.Value.Should().Be(urlmap.Url);
        }

        [Theory, DefaultAutoData]
        public void GetOriginalUrl_RecordNotFoundForDbId_ReturnsNotFoundResponse(
          [Frozen]IRepository<UrlMap, int> repository,
          [Frozen]IBase62Encoder encoder,
          [Frozen]IUrlMapContext context,
          [Frozen]string shortUrl,
          UrlController sut)
        {
            repository.FindAsync(210999).Returns((UrlMap)null);
            encoder.Decode(shortUrl).Returns(210999);
            context.UrlMaps.Returns(repository);

            var actionResult = Task.Run(async () => await sut.GetOriginalUrl(shortUrl)).GetAwaiter().GetResult();

            actionResult.Should().BeOfType<ObjectResult>().Which.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
            actionResult.Value.Should().Be(ResponseMessages.UrlNotFound);
        }

        [Theory, DefaultAutoData]
        public void GetOriginalUrl_ExceptionOccured_ReturnsInternalServerErrorResponseWithException(
            [Frozen]IBase62Encoder encoder,
            [Frozen]string shortUrl,
            Exception ex,
            UrlController sut)
        {
            encoder.Decode(shortUrl).Throws(ex);

            var actionResult = Task.Run(async () => await sut.GetOriginalUrl(shortUrl)).GetAwaiter().GetResult();

            actionResult.Should().BeOfType<ObjectResult>().Which.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError);
            actionResult.Value.Should().Be(ex.ToString());
        }
    }
}
