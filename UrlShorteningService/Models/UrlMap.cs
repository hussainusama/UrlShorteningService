namespace UrlShorteningService.Models
{
    public class UrlMap
    {
        public int Id { get; set; }
        public string LongUrl { get; set; }

        public override bool Equals(object obj)
        {
            return ((UrlMap)obj).LongUrl == LongUrl;
        }
    }
}