using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShorteningService.Model.Repositories
{
    public interface IRepository<TEntity, in TKey> where TEntity : class
    {
        void Add(TEntity entity);
        bool Remove(TEntity entity);
        Task<TEntity> GetByKeyAsync(TKey key);
        TEntity Create();
    }
}