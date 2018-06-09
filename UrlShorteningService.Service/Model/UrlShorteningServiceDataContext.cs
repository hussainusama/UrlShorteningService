using System.Threading;
using System.Threading.Tasks;

namespace UrlShorteningService.Service.Model
{
    public class UrlShorteningServiceDataContext : IUrlShorteningServiceDataContext
    {
        private readonly UrlShorteningServiceModel _model;
        private readonly DbSetWrapper<IUrlMapping, UrlMapping> _mappings;

        public IEntityRepository<IUrlMapping> UrlMappings => _mappings;

        public UrlShorteningServiceDataContext()
        {
            _model = new UrlShorteningServiceModel();
            _mappings = new DbSetWrapper<IUrlMapping, UrlMapping>(_model.UrlMappings);
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