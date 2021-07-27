using E_WaveStore.DataLayer.Entity;
using E_WaveStore.DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Repositories.Implementations
{
    public class LaptopRepository : BaseRepository<Laptop>, ILaptopRepository
    {
        public LaptopRepository(StoreDbContext storeDbContext) : base(storeDbContext) { }

        public Laptop GetLaptopByModelName(string modelName)
        {
            return _storeDbContext.Laptops.SingleOrDefault(x => x.ModelName == modelName);
        }

        public List<Laptop> GetLaptopByBrandName(string brandName)
        {
            return _storeDbContext.Laptops.Where(x => x.BrandName == brandName).ToList();
        }
    }
}
