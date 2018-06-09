using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace UrlShorteningService.Service.Model
{
    public class DbSetWrapper<T, TO> : IEntityRepository<T> where T : class where TO : class, T, new()
    {
        private readonly IDbSet<TO> _dbset;

        public DbSetWrapper(IDbSet<TO> dbset)
        {
            _dbset = dbset;
        }

        public void Add(T entity)
        {
            _dbset.Add((TO)entity);
        }

        public bool Remove(T entity)
        {
            return _dbset.Remove((TO)entity) != null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _dbset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dbset.GetEnumerator();
        }

        public Type ElementType => _dbset.ElementType;

        public Expression Expression => _dbset.Expression;

        public IQueryProvider Provider => _dbset.Provider;

        public T Create()
        {
            return Activator.CreateInstance<TO>();
        }
    }
}