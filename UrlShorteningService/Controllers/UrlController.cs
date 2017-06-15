using Microsoft.Practices.ServiceLocation;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using UrlShorteningService.Processors;
using System.Threading.Tasks;

namespace UrlShorteningService.Controllers
{
    [RoutePrefix("api/url")]
    public class UrlController : ApiController
    {
        IUrlProcessor _processor;

        UrlController() : this(ServiceLocator.Current.GetInstance<IUrlProcessor>())
        {

        }

        UrlController(IUrlProcessor processor)
        {
            this._processor = processor;
        }

        [HttpGet]
        [ActionName("shorten")]
        public async Task<HttpResponseMessage> ShortenAsync(string longUrl)
        {
            var shortUrl = await _processor.DeflateAsync(longUrl);
            var result = string.Concat(Url.Content("~/"), shortUrl);

            var resp = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(result, Encoding.UTF8, "text/plain")
            };
            return resp;

        }
    }
}
