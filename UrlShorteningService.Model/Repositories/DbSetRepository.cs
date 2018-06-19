using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UrlShorteningService.Model.Repositories
{
    public class DbSetRepository<TEntity, TKey> : IEntityRepository<TEntity, TKey> where TEntity : class
    {
        private readonly IDbSet<TEntity> _dbSetInterface;
        private readonly DbSet<TEntity> _dbSetImpl;

        public Type ElementType => _dbSetInterface.ElementType;

        public Expression Expression => _dbSetInterface.Expression;

        public IQueryProvider Provider => _dbSetInterface.Provider;

        public DbSetRepository(DbSet<TEntity> dbset)
        {
            _dbSetImpl = dbset;
            _dbSetInterface = dbset;
        }

        public void Add(TEntity entity)
        {
            _dbSetInterface.Add(entity);
        }

        public bool Remove(TEntity entity)
        {
            return _dbSetInterface.Remove(entity) != null;
        }

        public async Task<TEntity> GetByKeyAsync(TKey key)
        {
           return await _dbSetImpl.FindAsync(key);
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return _dbSetInterface.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dbSetInterface.GetEnumerator();
        }

        public TEntity Create()
        {
            return _dbSetInterface.Create();
        }
    }
}