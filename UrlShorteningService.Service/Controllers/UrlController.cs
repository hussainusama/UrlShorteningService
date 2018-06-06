using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Threading.Tasks;
using UrlShorteningService.Service.UrlProcessors;

namespace UrlShorteningService.Controllers
{
    [RoutePrefix("api/url")]
    public class UrlController : ApiController
    {
        readonly IUrlProcessor _processor;

        private UrlController(IUrlProcessor processor)
        {
            _processor = processor;
        }

        [HttpGet]
        [Route("shorten")]
        public async Task<HttpResponseMessage> DeflateAsync([FromUri]string longUrl)
        {
            var shortUrl = await _processor.DeflateAsync(longUrl);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(shortUrl, Encoding.UTF8, "text/plain")
            };
        }

        [HttpGet]
        [Route("lengthen")]
        public async Task<HttpResponseMessage> InflateAsync([FromUri]string shortUrl)
        {
            var longUrl = await _processor.InflateAsync(shortUrl);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(longUrl, Encoding.UTF8, "text/plain")
            };
        }
    }
}
