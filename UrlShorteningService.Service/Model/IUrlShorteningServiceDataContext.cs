using System;
using System.Threading;
using System.Threading.Tasks;

namespace UrlShorteningService.Service.Model
{
    public interface IUrlShorteningServiceDataContext : IDisposable
    {
        IEntityRepository<IUrlMapping> UrlMappings { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}