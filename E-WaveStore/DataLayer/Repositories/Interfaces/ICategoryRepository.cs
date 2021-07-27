using E_WaveStore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Category Get(long id);
        List<Category> GetAll();
        void Remove(Category model);
        Category Save(Category model);
        Category GetCategoryByName(string categoryName);
    }
}
