using System;
using System.Threading;
using System.Threading.Tasks;
using UrlShorteningService.Service.Model.Repositories;
using UrlShorteningService.Service.Model.Types;

namespace UrlShorteningService.Service.Model.DataContexts
{
    public interface IUrlMappingsDataContext : IDisposable
    {
        IEntityRepository<IUrlMapping> UrlMappings { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}