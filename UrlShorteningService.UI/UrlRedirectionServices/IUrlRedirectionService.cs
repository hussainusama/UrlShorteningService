using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace UrlShorteningService.UI.UrlRedirectionServices
{
    public interface IUrlRedirectionService
    {
        Task RetreiveAndRedirectAsync(HttpContext context, string shortUrl);
    }
}