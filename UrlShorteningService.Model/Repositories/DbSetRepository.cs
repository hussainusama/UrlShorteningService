﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UrlShorteningService.Model.Repositories
{
    public class DbSetRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;

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

        public TEntity Create()
        {
            return _dbSet.Create();
        }
    }
}