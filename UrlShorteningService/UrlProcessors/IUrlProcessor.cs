using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace UrlShorteningService.Processors
{
    public interface IUrlProcessor
    {
        Task<string> DeflateAsync(string longUrl);

        Task<string> InflateAsync(string shortUrl);

    }
}