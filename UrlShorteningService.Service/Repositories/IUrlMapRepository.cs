using System.Threading.Tasks;

namespace UrlShorteningService.Service.Repositories
{
    public interface IUrlMapRepository
    {
        Task<int> InsertAsync(string longUrl);
        Task<string> GetByIdAsync(int id);
    }
}