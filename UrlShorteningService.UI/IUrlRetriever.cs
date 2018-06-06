using System.Threading.Tasks;

namespace UrlShorteningService.UrlProcessors
{
    internal interface IUrlRetriever
    {
        Task<string> RetreiveUrlAsync(string shortUrl);
    }
}