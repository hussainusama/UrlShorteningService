using Microsoft.Practices.ServiceLocation;
using System.Web;
using UrlShorteningService.Processors;

namespace UrlShorteningService.HttpHandlers
{
    public class ShortUrlHttpHandler : IHttpHandler
    {
        IUrlProcessor _processor;
        public ShortUrlHttpHandler() : this(ServiceLocator.Current.GetInstance<IUrlProcessor>())
        {

        }
        public ShortUrlHttpHandler(IUrlProcessor processor)
        {
            this._processor = processor;
        }

        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest Request = context.Request;
            HttpResponse Response = context.Response;
            var deflatedurl = GetInflatedUrl(context, Request.Path.Substring(1));
            Response.Redirect(deflatedurl);
        }

        private string GetInflatedUrl(HttpContext context, string shorturl)
        {
            var longUrl = context.Cache[shorturl];
            if (longUrl == null)
            {
                longUrl = _processor.Inflate(shorturl);
                context.Cache[shorturl] = longUrl;
            }
            return longUrl.ToString();
        }
    }
}