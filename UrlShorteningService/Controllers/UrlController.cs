using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UrlShorteningService.Processors;

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

        [Route("shorten")]
        [HttpPost]
        public async System.Threading.Tasks.Task<string> ShortenAsync([FromBody] string longUrl)
        {
            var shortUrl = await _processor.DeflateAsync(longUrl);
            return string.Concat(Url.Content("~/") + shortUrl);
        }
    }
}
