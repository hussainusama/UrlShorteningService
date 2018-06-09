using System.Threading.Tasks;

namespace UrlShorteningService.Service.Repositories
{
    public interface IUrlMapRepository
    {
        Task<int> AddAsync(string longUrl);
        Task<string> GetByIdAsync(int id);
    }
}