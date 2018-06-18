using System.Threading.Tasks;
using UrlShorteningService.Model.DataContexts;
using UrlShorteningService.Model.Types;
using UrlShorteningService.Service.Encoders;

namespace UrlShorteningService.Service.UrlProcessors
{
    public class Base62UrlProcessor : IUrlProcessor
    {
        private readonly IUrlMappingsDataContext _urlMappingsDataContext;
        private readonly IBase62Encoder _base62Encoder;

        public Base62UrlProcessor(IUrlMappingsDataContext urlMappingsDataContext, IBase62Encoder base62Encoder)
        {
            _urlMappingsDataContext = urlMappingsDataContext;
            _base62Encoder = base62Encoder;
        }

        public async Task<string> DeflateAsync(string longUrl)
        {
            UrlMapping mapping = CreateAndAddMappingToContext(longUrl);
            await _urlMappingsDataContext.SaveChangesAsync();
            return EncodeIdToBase62String(mapping.Id);
        }

        private UrlMapping CreateAndAddMappingToContext(string longUrl)
        {
            UrlMapping mapping = _urlMappingsDataContext.UrlMappings.Create();
            mapping.Url = longUrl;
            _urlMappingsDataContext.UrlMappings.Add(mapping);
            return mapping;
        }

        private string EncodeIdToBase62String(int id)
        {
            return _base62Encoder.Encode(id);
        }

        public async Task<string> InflateAsync(string shortUrl)
        {
            var id = _base62Encoder.Decode(shortUrl);
            var mapping = await _urlMappingsDataContext.UrlMappings.GetByKeyAsync(id);
            return mapping.Url;
        }
    }
}