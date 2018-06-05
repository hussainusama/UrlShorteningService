using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace UrlShorteningService.UrlProcessors
{
    public interface IUrlRedirectionService
    {
        Task InflateAndRedirectAsync(HttpContext context, string shortUrl);
    }
}