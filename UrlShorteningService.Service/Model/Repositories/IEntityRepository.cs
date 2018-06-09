using System.Linq;

namespace UrlShorteningService.Service.Model.Repositories
{
    public interface IEntityRepository<T> : IQueryable<T> where T : class
    {
        void Add(T entity);

        bool Remove(T entity);

        T Create();
    }
}