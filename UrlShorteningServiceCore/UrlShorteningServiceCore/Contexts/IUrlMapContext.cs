using System.Threading.Tasks;
using UrlShorteningService.Models;
using UrlShorteningService.Repositories;

namespace UrlShorteningService.Contexts
{
    public interface IUrlMapContext
    {
        IRepository<UrlMap, int> UrlMaps { get; }

        Task<int> SaveChangesAsync();
    }
}