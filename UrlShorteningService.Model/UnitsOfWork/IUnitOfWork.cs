using System;
using System.Threading;
using System.Threading.Tasks;
using UrlShorteningService.Model.Repositories;
using UrlShorteningService.Model.Types;

namespace UrlShorteningService.Model.UnitsOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<UrlMapping, int> UrlMappingsRepository { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}