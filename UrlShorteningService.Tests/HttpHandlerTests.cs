using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using UrlShorteningService.HttpHandlers;
using UrlShorteningService.Processors;

namespace UrlShorteningService.Tests
{
    [TestClass]
    public class HttpHandlerTests
    {
        [TestMethod]
        public void TestMethod2()
        {
            FakeUrlMapRepository repo = new FakeUrlMapRepository(1234566);
            repo.Insert(new Models.UrlMap() { LongUrl = "http://www.google.com" });

            StringBuilder output = new StringBuilder();
            using (StringWriter sw = new StringWriter(output))
            {
                HttpResponse response = new HttpResponse(sw);
                HttpRequest request = new HttpRequest("", "http://urlshorteningservice.com/NAB5", "");
                request.Browser = new HttpBrowserCapabilities();
                request.Browser.Capabilities = new Dictionary<string, string> { { "requiresPostRedirectionHandling", "false" } };
                HttpContext context = new HttpContext(request, response);
                new ShortUrlHttpHandler(new Base62UrlProcessor(repo, new FakeBase62Encoder())).ProcessRequest(context);
            }
            var html = output.ToString();
            var redirect = "Object moved to <a href=\"http://www.google.com\">here</a>";
            Assert.AreEqual(true, html.Contains(redirect));
        }
    }
}
