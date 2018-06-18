using System.Linq;
using System.Threading.Tasks;

namespace UrlShorteningService.Model.Repositories
{
    public interface IEntityRepository<TEntity, in TKey> : IQueryable<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        bool Remove(TEntity entity);
        Task<TEntity> GetByKeyAsync(TKey key);
        TEntity Create();
    }
}