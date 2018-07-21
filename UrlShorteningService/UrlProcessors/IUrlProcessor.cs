﻿using System.Threading.Tasks;

namespace UrlShorteningService.UrlProcessors
{
    public interface IUrlProcessor
    {
        Task<string> DeflateAsync(string longUrl);

        Task<string> InflateAsync(string shortUrl);

    }
}