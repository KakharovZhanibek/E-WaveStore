﻿using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Implementations
{
    public abstract class BaseRepository<DbModel> : IBaseRepository<DbModel> where DbModel : BaseModel
    {
        protected ApplicationContext _storeDbContext;
        protected DbSet<DbModel> _dbSet;

        public BaseRepository(ApplicationContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
            _dbSet = _storeDbContext.Set<DbModel>();
        }

        public DbModel Get(long id)
        {
            return _dbSet.SingleOrDefault(x => x.Id == id);
        }

        public List<DbModel> GetAll()
        {
            return _dbSet.ToList();
        }

        public DbModel Save(DbModel model)
        {
            if (model.Id > 0)
            {
                _storeDbContext.Entry(model).State = EntityState.Modified;
            }
            else
            {
                _storeDbContext.Entry(model).State = EntityState.Unchanged;
                _dbSet.Add(model);
            }

            _storeDbContext.SaveChanges();
            return model;
        }

        public void Remove(DbModel model)
        {
            _dbSet.Remove(model);
            _storeDbContext.SaveChanges();
        }

        public void Update(DbModel model)
        {
            _storeDbContext.Entry(model).State = EntityState.Modified;
            _storeDbContext.SaveChanges();
        }

        public IQueryable<DbModel> GetAllAsIQueryable()
        {
            return _dbSet.AsQueryable();
        }
    }
}