using Microsoft.Practices.ServiceLocation;
using System.Web;
using UrlShorteningService.Processors;
using System;
using System.Threading.Tasks;

namespace UrlShorteningService.HttpHandlers
{
    public class ShortUrlHttpHandler : HttpTaskAsyncHandler
    {
        IUrlProcessor _processor;
        public ShortUrlHttpHandler() : this(ServiceLocator.Current.GetInstance<IUrlProcessor>())
        {

        }
        public ShortUrlHttpHandler(IUrlProcessor processor)
        {
            this._processor = processor;
        }

        public override bool IsReusable => false;

        public override async Task ProcessRequestAsync(HttpContext context)
        {
            HttpRequest Request = context.Request;
            HttpResponse Response = context.Response;
            var deflatedurl = await GetInflatedUrlAsync(context, Request.Path.Substring(1)).ConfigureAwait(false);
            Response.Redirect(deflatedurl);
        }

        private async Task<string> GetInflatedUrlAsync(HttpContext context, string shorturl)
        {
            var longUrl = context.Cache[shorturl];
            if (longUrl == null)
            {
                longUrl = await _processor.InflateAsync(shorturl).ConfigureAwait(false);
                context.Cache[shorturl] = longUrl;
            }
            return longUrl.ToString();
        }
    }
}