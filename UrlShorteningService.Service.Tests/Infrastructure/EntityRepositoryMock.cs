using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NSubstitute;
using UrlShorteningService.Service.Model;

namespace UrlShorteningService.Service.Tests.Infrastructure
{
    public class EntityRepositoryMock<T> : List<T>, IEntityRepository<T>
        where T : class
    {
        private readonly Func<T> _factory;

        public EntityRepositoryMock(Func<T> factory)
        {
            _factory = factory;
        }

        public EntityRepositoryMock()
            : this(() => Substitute.For<T>())
        {
        }

        private IQueryable<T> Queryable => ToArray().AsQueryable();

        bool IEntityRepository<T>.Remove(T entity)
        {
            return Remove(entity);
        }

        public Type ElementType => Queryable.ElementType;

        public Expression Expression => Queryable.Expression;

        public IQueryProvider Provider => Queryable.Provider;


        public T Create()
        {
            return _factory();
        }
    }
}
