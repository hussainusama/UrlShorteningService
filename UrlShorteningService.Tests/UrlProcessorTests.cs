using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrlShorteningService.Processors;

namespace UrlShorteningService.Tests
{
    [TestClass]
    public class UrlProcessorTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var urlLong = "https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application";

            Base62UrlProcessor processor = new Base62UrlProcessor(new FakeUrlMapRepository(0), new Base62Encoder());
            var urlShort = processor.Deflate(urlLong);

            Assert.AreEqual(urlLong, processor.Inflate(urlShort));
        }

        public void TestMethod2()
        {
            var urlLong = "https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application";

            Base62UrlProcessor processor = new Base62UrlProcessor(new FakeUrlMapRepository(0), new Base62Encoder());
            var urlShort = processor.Deflate(urlLong);

            Assert.AreEqual(urlShort, processor.Deflate(urlLong));
        }
    }
}
