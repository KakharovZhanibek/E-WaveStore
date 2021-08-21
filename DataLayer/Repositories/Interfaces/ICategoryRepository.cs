
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Category GetByCategoryName(string categoryName);
    }
}
