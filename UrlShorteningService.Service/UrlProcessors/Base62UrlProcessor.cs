using System.Threading.Tasks;
using UrlShorteningService.Service.Encoders;
using UrlShorteningService.Service.Services;

namespace UrlShorteningService.Service.UrlProcessors
{
    public class Base62UrlProcessor : IUrlProcessor
    {
        private readonly IUrlMappingService _mappingService;
        private readonly IBase62Encoder _base62Encoder;

        public Base62UrlProcessor(IUrlMappingService mappingService, IBase62Encoder base62Encoder)
        {
            _mappingService = mappingService;
            _base62Encoder = base62Encoder;
        }

        public async Task<string> DeflateAsync(string longUrl)
        {
            var id = await _mappingService.AddAsync(longUrl);
            return _base62Encoder.Encode(id);
        }

        public async Task<string> InflateAsync(string shortUrl)
        {
            var mapping = await _mappingService.GetAsync(_base62Encoder.Decode(shortUrl));
            return mapping.Url;
        }
    }
}