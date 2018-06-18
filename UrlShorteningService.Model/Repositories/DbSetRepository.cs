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
        private readonly DbSet<TEntity> _dbSet;

        public Type ElementType => (_dbSet as IDbSet<TEntity>).ElementType;

        public Expression Expression => (_dbSet as IDbSet<TEntity>).Expression;

        public IQueryProvider Provider => (_dbSet as IDbSet<TEntity>).Provider;

        public DbSetRepository(DbSet<TEntity> dbset)
        {
            _dbSet = dbset;
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public bool Remove(TEntity entity)
        {
            return _dbSet.Remove(entity) != null;
        }

        public async Task<TEntity> GetByKeyAsync(TKey key)
        {
           return await _dbSet.FindAsync(key);
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return (_dbSet as IDbSet<TEntity>).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (_dbSet as IDbSet<TEntity>).GetEnumerator();
        }

        public TEntity Create()
        {
            return _dbSet.Create();
        }
    }
}