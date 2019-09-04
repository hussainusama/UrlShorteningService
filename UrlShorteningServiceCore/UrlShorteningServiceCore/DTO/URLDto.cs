using System;

namespace UrlShorteningService.DTO
{
    public class UrlDto
    {
        public string LongUrl { get; set; }

        public bool HasValidUrl()
        {
            return Uri.TryCreate(LongUrl, UriKind.Absolute, out var uri)
                && (uri.Scheme == Uri.UriSchemeHttp
                    || uri.Scheme == Uri.UriSchemeHttps
                    || uri.Scheme == Uri.UriSchemeFtp
                    || uri.Scheme == Uri.UriSchemeMailto);
        }
            
    }
}