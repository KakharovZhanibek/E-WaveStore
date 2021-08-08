﻿using E_WaveStore.DataLayer.Entity;
using E_WaveStore.DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Repositories.Implementations
{   
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationContext storeDbContext) : base(storeDbContext) { }
          
        public Category GetByCategoryName(string categoryName)
        {
            return _storeDbContext.Categories.SingleOrDefault(x => x.CategoryName == categoryName);
        }
    }
}
