using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using UrlShorteningService.Model.Repositories;
using UrlShorteningService.Model.Types;

namespace UrlShorteningService.Model.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UrlShorteningServiceContext _context;
        private readonly DbSetRepository<UrlMapping, int> _mappings;

        public IRepository<UrlMapping, int> UrlMappingsRepository => _mappings;

        public UnitOfWork(UrlShorteningServiceContext context)
        {
            _context = context;
            _mappings = new DbSetRepository<UrlMapping, int>(_context.UrlMappings);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}