using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShorteningService.Contexts;
using UrlShorteningService.DTO;
using UrlShorteningService.Encoders;
using UrlShorteningService.Models;
using UrlShorteningService.Texts;

namespace UrlShorteningService.Controllers
{
    [Route("api/url")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IUrlMapContext _context;
        private readonly IBase62Encoder _base62Encoder;

        public UrlController(IUrlMapContext context, IBase62Encoder base62Encoder)
        {
            _context = context;
            _base62Encoder = base62Encoder;
        }

        [HttpPost]
        [Route("shorten")]
        [EnableCors]
        public async Task<ObjectResult> GetEncodedUrl([FromBody]UrlDto urlDto)
        {
            try
            {
                if (!urlDto.HasValidUrl()) return StatusCode(StatusCodes.Status400BadRequest, ResponseMessages.InvalidUrl);

                var databaseId = await CreateAndSaveMappingToDataBase(urlDto.LongUrl);
                var shortUrl = EncodeDatabaseIdToString(databaseId);
                
                return StatusCode(StatusCodes.Status200OK, shortUrl);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        
        }
     
        [HttpGet]
        [Route("lengthen")]
        [EnableCors]
        public async Task<ObjectResult> GetOriginalUrl([FromQuery]string encodedUrl)
        {
            try
            {
                var databaseId = DecodeStringToDatabaseId(encodedUrl);
                var mapping = await GetMappingFromDataBase(databaseId);

                if (mapping == null) return StatusCode(StatusCodes.Status404NotFound, ResponseMessages.UrlNotFound);
               
                return StatusCode(StatusCodes.Status200OK, mapping.Url);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        private async Task<int> CreateAndSaveMappingToDataBase(string longUrl)
        {
            UrlMap mapping =  _context.UrlMaps.Create();
            mapping.Url = longUrl;
            _context.UrlMaps.Add(mapping);
            await _context.SaveChangesAsync();
            return mapping.Id;
        }

        private async Task<UrlMap> GetMappingFromDataBase(int id)
        {
            return await _context.UrlMaps.FindAsync(id);
        }
        
        private string EncodeDatabaseIdToString(int id)
        {
            return _base62Encoder.Encode(id);
        }

        private int DecodeStringToDatabaseId(string shortUrl)
        {
            return _base62Encoder.Decode(shortUrl);
        }
    }
}
