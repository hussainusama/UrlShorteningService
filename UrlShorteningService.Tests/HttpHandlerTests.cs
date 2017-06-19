using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using UrlShorteningService.HttpHandlers;
using UrlShorteningService.UrlProcessors;

namespace UrlShorteningService.Tests
{
    [TestClass]
    public class HttpHandlerTests
    {
        [TestMethod]
        public void Invoke_ProcessRequest_ShouldRedirect()
        {
            var repo = new FakeUrlMapRepository(1234566);
            repo.InsertAsync("http://www.google.com");

            var output = new StringBuilder();
            using (var sw = new StringWriter(output))
            {
                var response = new HttpResponse(sw);
                var request = new HttpRequest("", "http://urlshorteningservice.com/NAB5", "")
                {
                    Browser = new HttpBrowserCapabilities
                    {
                        Capabilities = new Dictionary<string, string> {{"requiresPostRedirectionHandling", "false"}}
                    }
                };
                var context = new HttpContext(request, response);
                var handler = new ShortUrlHttpHandler(new Base62UrlProcessor(repo, new FakeBase62Encoder()));
                handler.ProcessRequestAsync(context).ConfigureAwait(false);
            }
            var html = output.ToString();
            var redirect = "Object moved to <a href=\"http://www.google.com\">here</a>";
            Assert.AreEqual(true, html.Contains(redirect));
        }
    }
}
