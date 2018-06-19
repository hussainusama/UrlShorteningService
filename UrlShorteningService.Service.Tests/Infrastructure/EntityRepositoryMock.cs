using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Xml.Schema;
using NSubstitute;
using UrlShorteningService.Model.Repositories;

namespace UrlShorteningService.Service.Tests.Infrastructure
{
    public class EntityRepositoryMock<T, TKey> : IRepository<T, TKey> where T : class, new()
    {
        private readonly List<T> _entities;

        public EntityRepositoryMock()
        {
            _entities = new List<T>();
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public bool Remove(T entity)
        {
            return _entities.Remove(entity);
        }

        public Task<T> GetByKeyAsync(TKey key)
        {
            throw new NotImplementedException();
        }

        public T Create()
        {
            return new T();
        }
    }
}
