using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UrlShorteningService.Repositories
{
    public class DbSetRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, new()
    {
        private readonly DbSet<TEntity> _dbSet;

        public DbSetRepository(DbSet<TEntity> dbSet)
        {
            _dbSet = dbSet;
        }
        
        public IEnumerator<TEntity> GetEnumerator()
        {
            return _dbSet.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public async Task<TEntity> FindAsync(TKey key)
        {
            return await _dbSet.FindAsync(key);
        }

        public TEntity Create()
        {
            return new TEntity();
        }
    }
}