using Microsoft.Practices.ServiceLocation;
using System.Web;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using UrlShorteningService.UrlProcessors;

namespace UrlShorteningService.HttpHandlers
{
    public class ShortUrlHttpHandler : HttpTaskAsyncHandler
    {
        readonly IUrlProcessor _processor;
        public ShortUrlHttpHandler() : this(ServiceLocator.Current.GetInstance<IUrlProcessor>())
        {

        }
        public ShortUrlHttpHandler(IUrlProcessor processor)
        {
            _processor = processor;
        }

        public override bool IsReusable => false;

        public override async Task ProcessRequestAsync(HttpContext context)
        {
            var request = context.Request;
            var response = context.Response;

            var path = request.Path.Substring(1);

            var regex = new Regex("^[a-zA-Z0-9]{1,6}$");
            if(regex.IsMatch(path))
            {
                var deflatedurl = await GetInflatedUrlAsync(context, path).ConfigureAwait(false);
                response.Redirect(deflatedurl);
            }
        }

        private async Task<string> GetInflatedUrlAsync(HttpContext context, string shorturl)
        {
            var longUrl = context.Cache[shorturl];
            if (longUrl != null) return longUrl.ToString();
            longUrl = await _processor.InflateAsync(shorturl).ConfigureAwait(false);
            context.Cache[shorturl] = longUrl;
            return longUrl.ToString();
        }
    }
}