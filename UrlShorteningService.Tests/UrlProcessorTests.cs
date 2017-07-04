using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrlShorteningService.UrlProcessors;

namespace UrlShorteningService.Tests
{
    [TestClass]
    public class UrlProcessorTests
    {
        [TestMethod]
        public async System.Threading.Tasks.Task ProcessUrl_DeflateThenInflate_InflatedEqualsUrl()
        {
            var urlLong = "https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application";

            var processor = new Base62UrlProcessor(new FakeUrlMapRepository(1233), new Base62Encoder());
            var urlDeflated = await processor.DeflateAsync(urlLong).ConfigureAwait(false);
            var urlInflated = await processor.InflateAsync(urlDeflated).ConfigureAwait(false);

            Assert.AreEqual(urlLong, urlInflated);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task ProcessUrl_Deflate_ReturnsShortStringofMinLength()
        {
            var urlLong = "https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application";

            var processor = new Base62UrlProcessor(new FakeUrlMapRepository(0), new Base62Encoder());
            var urlDeflated = await processor.DeflateAsync(urlLong).ConfigureAwait(false);

            Assert.IsTrue(urlDeflated.Length == 1);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task ProcessUrl_Deflate_ReturnsShortStringofMaxLength()
        {
            var urlLong = "https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application";

            var processor = new Base62UrlProcessor(new FakeUrlMapRepository(2147483646), new Base62Encoder());
            var urlDeflated = await processor.DeflateAsync(urlLong).ConfigureAwait(false);

            Assert.IsTrue(urlDeflated.Length == 6);
        }
    }
}
