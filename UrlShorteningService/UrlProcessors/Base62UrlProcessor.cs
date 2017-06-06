using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrlShorteningService.Models;

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

        public string Deflate(string longUrl)
        {
            var urlMap = new UrlMap { LongUrl = longUrl };
            repository.Insert(urlMap);
            return encoder.Encode(urlMap.Id);
        }

        public string Inflate(string shortUrl)
        {
            var id = encoder.Decode(shortUrl);
            var urlMap = repository.GetById(id);
            return urlMap.LongUrl;
        }
    }
}