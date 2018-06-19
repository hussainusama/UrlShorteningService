using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UrlShorteningService.Model.Repositories
{
    public class EntityFrameworkRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        private readonly DbContext _context;

        public EntityFrameworkRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public bool Remove(TEntity entity)
        {
            return _context.Set<TEntity>().Remove(entity) != null;
        }

        public async Task<TEntity> GetByKeyAsync(TKey key)
        {
            return await _context.Set<TEntity>().FindAsync(key);
        }

        public TEntity Create()
        {
            return _context.Set<TEntity>().Create();
        }
    }
}
