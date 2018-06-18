using System;
using System.Threading;
using System.Threading.Tasks;
using UrlShorteningService.Model.Repositories;
using UrlShorteningService.Model.Types;

namespace UrlShorteningService.Model.DataContexts
{
    public interface IUrlMappingsDataContext : IDisposable
    {
        IEntityRepository<UrlMapping, int> UrlMappings { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}