using E_WaveStore.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Repositories.Interfaces
{
    public interface ILaptopRepository : IBaseRepository<Laptop>
    {
        Laptop GetLaptopByModelName(string modelName);
        List<Laptop> GetLaptopByBrandName(string brandName);
    }
}
