﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrlShorteningService.Processors
{
    public interface IUrlProcessor
    {
        string Deflate(string longUrl);

        string Inflate(string shortUrl);

    }
}