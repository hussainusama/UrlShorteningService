using Microsoft.Practices.ServiceLocation;
using System.Web;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using UrlShorteningService.UrlProcessors;

namespace UrlShorteningService.HttpHandlers
{
    public class ShortUrlHttpHandler : HttpTaskAsyncHandler
    {
        readonly IUrlRedirectionService _urlRedirectionService;
        public ShortUrlHttpHandler() : this(ServiceLocator.Current.GetInstance<IUrlRedirectionService>())
        {
        }
        public ShortUrlHttpHandler(IUrlRedirectionService urlRedirectionService)
        {
            _urlRedirectionService = urlRedirectionService;
        }

        public override bool IsReusable => false;

        public override async Task ProcessRequestAsync(HttpContext context)
        {
            var path = context.Request.Path.Substring(1);
            var regex = new Regex("^[a-zA-Z0-9]{1,6}$");
            if(regex.IsMatch(path))
            {
               await _urlRedirectionService.RetreiveAndRedirectAsync(context, path);
            }
        }
    }
}