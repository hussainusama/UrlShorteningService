using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace UrlShorteningService.Service.Model.Repositories
{
    public class DbSetRepository<I, C> : IEntityRepository<I> where I : class where C : class, I, new()
    {
        private readonly IDbSet<C> _dbset;

        public Type ElementType => _dbset.ElementType;

        public Expression Expression => _dbset.Expression;

        public IQueryProvider Provider => _dbset.Provider;

        public DbSetRepository(IDbSet<C> dbset)
        {
            _dbset = dbset;
        }

        public void Add(I entity)
        {
            _dbset.Add((C)entity);
        }

        public bool Remove(I entity)
        {
            return _dbset.Remove((C)entity) != null;
        }

        public IEnumerator<I> GetEnumerator()
        {
            return _dbset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dbset.GetEnumerator();
        }

        public I Create()
        {
            return _dbset.Create<C>();
        }
    }
}