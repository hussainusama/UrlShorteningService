using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShorteningService.Processors;

namespace UrlShorteningService.Tests
{
    class FakeBase62Encoder : IBase62Encoder
    {
        Dictionary<int, string> mappings = new Dictionary<int, string>();
        Dictionary<string, int> reversemappings = new Dictionary<string, int>();
        public FakeBase62Encoder()
        {
            mappings.Add(1, "1");
            mappings.Add(12, "C");
            mappings.Add(123, "z1");
            mappings.Add(1234, "uJ");
            mappings.Add(12345, "7D3");
            mappings.Add(123456, "E7W");
            mappings.Add(1234567, "NAB5");

            reversemappings.Add("1", 1);
            reversemappings.Add("C", 12);
            reversemappings.Add("z1", 123);
            reversemappings.Add("uJ", 1234);
            reversemappings.Add("7D3", 12345);
            reversemappings.Add("E7W", 123456);
            reversemappings.Add("NAB5", 1234567);
        }

        public int Decode(string val)
        {
            return reversemappings[val];
        }

        public string Encode(int val)
        {
            return mappings[val];
        }
    }
}
