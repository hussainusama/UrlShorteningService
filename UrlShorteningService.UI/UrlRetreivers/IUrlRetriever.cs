using System.Threading.Tasks;

namespace UrlShorteningService.UI.UrlRetreivers
{
    internal interface IUrlRetriever
    {
        Task<string> RetreiveUrlAsync(string shortUrl);
    }
}