using E_WaveStore.DataLayer.Models.Entity;
using E_WaveStore.DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Repositories.Implementations
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext storeDbContext) : base(storeDbContext) { }

        public Product GetByModelName(string modelName)
        {
            var test = _storeDbContext.Products.SingleOrDefault(x => x.ModelName == modelName);
            return test;
            //return _storeDbContext.Products.SingleOrDefault(x => x.ModelName == modelName);
        }
        public List<Product> GetAllByBrandName(string brandName)
        {
            return _storeDbContext.Products.Where(x => x.BrandName == brandName).ToList();
        }

        public List<Product> GetAllByCategoryName(string categoryName)
        {
            return _storeDbContext.Products.Where(x => x.Category.CategoryName == categoryName).ToList();
        }

    }
}
