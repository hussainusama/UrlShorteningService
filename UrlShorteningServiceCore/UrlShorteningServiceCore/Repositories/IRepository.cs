using System.Collections.Generic;
using System.Threading.Tasks;

namespace UrlShorteningService.Repositories
{
    public interface IRepository<TEntity, in TKey> : IEnumerable<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        Task<TEntity> FindAsync(TKey key);
        TEntity Create();
    }
}