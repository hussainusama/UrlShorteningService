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
        public void ProcessNumber_EncodeThenDecode_DecodedEqualsNumber()
        {
            var num = 178549087;

            Base62Encoder encoder  = new Base62Encoder();
            var encodedString = encoder.Encode(num);

            Assert.AreEqual(num, encoder.Decode(encodedString));
        }

        [TestMethod]
        public void ProcessNumber_EncodeZero_ReturnsNothing()
        {
            var num = 0;

            Base62Encoder encoder = new Base62Encoder();
            var encodedString = encoder.Encode(num);

            Assert.IsTrue(encodedString.Length == 0);
        }

        [TestMethod]
        public void ProcessNumber_EncodeMinNumber_ReturnsEncodedStringOfMinLength()
        {
            var num = 1;

            Base62Encoder encoder = new Base62Encoder();
            var encodedString = encoder.Encode(num);

            Assert.IsTrue(encodedString.Length == 1);
        }

        [TestMethod]
        public void ProcessNumber_EncodeMaxNumber_ReturnsEncodedStringOfMaxLength()
        {
            var num = 2147483647;

            Base62Encoder encoder = new Base62Encoder();
            var encodedString = encoder.Encode(num);

            Assert.IsTrue(encodedString.Length == 6);
        }


        [TestMethod]
        public void ProcessNumber_EncodeSameNumberTwice_ReturnsSameEncodedString()
        {
            var num = 214563278;

            Base62Encoder encoder = new Base62Encoder();
            var encodedString = encoder.Encode(num);

            Assert.AreEqual(encodedString, encoder.Encode(num));
        }

        [TestMethod]
        public void ProcessShortString_DecodeSameStringTwice_ReturnsSameNumber()
        {
            var shortString = "E7W";

            Base62Encoder encoder = new Base62Encoder();
            var num = encoder.Decode(shortString);

            Assert.AreEqual(num, encoder.Decode(shortString));
        }
    }
}
