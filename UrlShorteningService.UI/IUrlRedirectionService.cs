using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace UrlShorteningService.UrlProcessors
{
    public interface IUrlRedirectionService
    {
        Task RetreiveAndRedirectAsync(HttpContext context, string shortUrl);
    }
}