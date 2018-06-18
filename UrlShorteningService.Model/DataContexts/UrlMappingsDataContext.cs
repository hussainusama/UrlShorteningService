using System.Threading;
using System.Threading.Tasks;
using UrlShorteningService.Model.Repositories;
using UrlShorteningService.Model.Types;

namespace UrlShorteningService.Model.DataContexts
{
    public class UrlMappingsDataContext : IUrlMappingsDataContext
    {
        private readonly UrlShorteningServiceModel _model;
        private readonly DbSetRepository<UrlMapping, int> _mappings;

        public IEntityRepository<UrlMapping, int> UrlMappings => _mappings;

        public UrlMappingsDataContext()
        {
            _model = new UrlShorteningServiceModel();
            _mappings = new DbSetRepository<UrlMapping, int>(_model.UrlMappings);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return _model.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _model.Dispose();
        }
    }
}