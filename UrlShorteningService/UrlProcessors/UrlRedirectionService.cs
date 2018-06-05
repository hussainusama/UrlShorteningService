using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace UrlShorteningService.UrlProcessors
{
    public class UrlRedirectionService: IUrlRedirectionService
    {
        private readonly IUrlRetriever _urlRetreiver;

        UrlRedirectionService(IUrlRetriever urlRetreiver)
        {
            _urlRetreiver = urlRetreiver;
        }
        public async Task InflateAndRedirectAsync(HttpContext context, string shortUrl)
        {
            context.Response.Redirect(await _urlRetreiver.RetreiveUrlAsync(shortUrl).ConfigureAwait(false));
        }


        //private async Task<string> GetInflatedUrlAsync(HttpContext context, string shorturl)
        //{
        //    var longUrl = context.Cache[shorturl];
        //    if (longUrl != null) return longUrl.ToString();
        //    longUrl = await _urlProcessor.InflateAsync(shorturl).ConfigureAwait(false);
        //    context.Cache[shorturl] = longUrl;
        //    return longUrl.ToString();
        //}
    }
}