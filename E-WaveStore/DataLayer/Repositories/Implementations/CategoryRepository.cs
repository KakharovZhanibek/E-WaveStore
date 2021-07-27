using E_WaveStore.DataLayer.Repositories.Interfaces;
using E_WaveStore.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        protected StoreDbContext _storeDbContext;

        public CategoryRepository(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }

        public Category Get(long id)
        {
            return _storeDbContext.Categories.SingleOrDefault(x => x.Id == id);
        }

        public List<Category> GetAll()
        {
            return _storeDbContext.Categories.ToList();
        }

        public Category Save(Category model)
        {
            if (model.Id > 0)
            {
                //_dbSet.Update(model);
                _storeDbContext.Entry(model).State = EntityState.Modified;
            }
            else
            {
                _storeDbContext.Categories.Add(model);
            }

            _storeDbContext.SaveChanges();

            return model;
        }

        public void Remove(Category model)
        {
            _storeDbContext.Categories.Remove(model);
            _storeDbContext.SaveChanges();
        }

        public void Update(Category model)
        {
            _storeDbContext.Entry(model).State = EntityState.Modified;
            _storeDbContext.SaveChanges();
        }

        public Category GetCategoryByName(string categoryName)
        {
            return _storeDbContext.Categories.SingleOrDefault(x => x.CategoryName == categoryName);
        }

    }
}
