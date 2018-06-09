using System.Threading;
using System.Threading.Tasks;
using UrlShorteningService.Service.Model.Repositories;
using UrlShorteningService.Service.Model.Types;

namespace UrlShorteningService.Service.Model.DataContexts
{
    public class UrlMappingsDataContext : IUrlMappingsDataContext
    {
        private readonly UrlShorteningServiceModel _model;
        private readonly DbSetRepository<IUrlMapping, UrlMapping> _mappings;

        public IEntityRepository<IUrlMapping> UrlMappings => _mappings;

        public UrlMappingsDataContext()
        {
            _model = new UrlShorteningServiceModel();
            _mappings = new DbSetRepository<IUrlMapping, UrlMapping>(_model.UrlMappings);
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