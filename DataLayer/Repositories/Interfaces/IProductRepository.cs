using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Product GetByModelName(string modelName);
        List<Product> GetAllByBrandName(string brandName);
        List<Product> GetAllByCategoryName(string categoryName);
    }
}
