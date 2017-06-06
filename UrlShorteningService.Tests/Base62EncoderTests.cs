using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShorteningService.Processors;

namespace UrlShorteningService.Tests
{
    [TestClass]
    public class Base62EncoderTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var num = 178549087;

            Base62Encoder encoder  = new Base62Encoder();
            var encodedNum = encoder.Encode(num);

            Assert.AreEqual(encodedNum, encoder.Decode(encodedNum));
        }
    }
}
