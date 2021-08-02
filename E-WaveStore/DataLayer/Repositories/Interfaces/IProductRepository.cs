using E_WaveStore.DataLayer.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Repositories.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Product GetByModelName(string modelName);
        List<Product> GetAllByBrandName(string brandName);
    }
}
