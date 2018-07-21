using Microsoft.Practices.ServiceLocation;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Threading.Tasks;
using UrlShorteningService.UrlProcessors;

namespace UrlShorteningService.Controllers
{
    [RoutePrefix("api/url")]
    public class UrlController : ApiController
    {
        readonly IUrlProcessor _processor;

        public UrlController() : this(processor: ServiceLocator.Current.GetInstance<IUrlProcessor>())
        {

        }

        private UrlController(IUrlProcessor processor)
        {
            _processor = processor;
        }

        [HttpGet]
        [ActionName("shorten")]
        public async Task<HttpResponseMessage> DeflateAsync(string longUrl)
        {
            var shortUrl = await _processor.DeflateAsync(longUrl);
            var result = string.Concat(Url.Content("~/"), shortUrl);

            var resp = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(result, Encoding.UTF8, "text/plain")
            };
            return resp;

        }

        [HttpGet]
        [ActionName("lengthen")]
        public async Task<HttpResponseMessage> InflateAsync(string shortUrl)
        {
            var longUrl = await _processor.InflateAsync(shortUrl);
            var resp = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(longUrl, Encoding.UTF8, "text/plain")
            };
            return resp;

        }
    }
}
