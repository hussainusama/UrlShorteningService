using System.Threading.Tasks;
using UrlShorteningService.Models;
using UrlShorteningService.Repositories;

namespace UrlShorteningService.Contexts
{
    public class UrlMapContextWrapper : IUrlMapContext
    {
        private readonly UrlMapContext _context;
        private readonly DbSetRepository<UrlMap, int> _urlMaps;

        public UrlMapContextWrapper(UrlMapContext context)
        {
            _context = context;
            _urlMaps = new DbSetRepository<UrlMap, int>(_context.UrlMaps);
        }

        public IRepository<UrlMap, int> UrlMaps => _urlMaps;

        public async Task<int> SaveChangesAsync()
        {
           return await _context.SaveChangesAsync();
        }
    }
}