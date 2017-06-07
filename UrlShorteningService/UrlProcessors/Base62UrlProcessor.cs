using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrlShorteningService.Models;
using System.Threading.Tasks;

namespace UrlShorteningService.Processors
{
    public class Base62UrlProcessor : IUrlProcessor
    {

        IUrlMapRepository repository;
        IBase62Encoder encoder;

        public Base62UrlProcessor(IUrlMapRepository repository, IBase62Encoder encoder)
        {
            this.repository = repository;
            this.encoder = encoder;
        }

        public async Task<string> DeflateAsync(string longUrl)
        {
            var id = await repository.InsertAsync(longUrl);
            return encoder.Encode(id);
        }

        public async Task<string> InflateAsync(string shortUrl)
        {
            var id = encoder.Decode(shortUrl);
            return await repository.GetByIdAsync(id);
        }
    }
}