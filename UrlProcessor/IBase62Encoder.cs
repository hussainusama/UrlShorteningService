using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrlShorteningService
{
    public interface IBase62Encoder
    {
        string Encode(int val);

        int Decode(string val);
    }
}