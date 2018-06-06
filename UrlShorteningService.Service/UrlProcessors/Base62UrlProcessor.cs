using System.Threading.Tasks;
using UrlShorteningService.Service.Repositories;
using UrlShorteningService.Service.Encoders;

namespace UrlShorteningService.Service.UrlProcessors
{
    public class Base62UrlProcessor : IUrlProcessor
    {
        private readonly IUrlMapRepository _urlMapRepository;
        private readonly IBase62Encoder _base62Encoder;

        public Base62UrlProcessor(IUrlMapRepository urlMapRepository, IBase62Encoder base62Encoder)
        {
            _urlMapRepository = urlMapRepository;
            _base62Encoder = base62Encoder;
        }

        public async Task<string> DeflateAsync(string longUrl)
        {
            var id = await _urlMapRepository.InsertAsync(longUrl);
            return _base62Encoder.Encode(id);
        }

        public async Task<string> InflateAsync(string shortUrl)
        {
            var id = _base62Encoder.Decode(shortUrl);
            return await _urlMapRepository.GetByIdAsync(id);
        }
    }
}