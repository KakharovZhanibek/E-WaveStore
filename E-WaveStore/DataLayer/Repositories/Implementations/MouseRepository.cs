using E_WaveStore.DataLayer.Entity;
using E_WaveStore.DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Repositories.Implementations
{
    public class MouseRepository : BaseRepository<Mouse>, IMouseRepository
    {
        public MouseRepository(StoreDbContext storeDbContext) : base(storeDbContext) { }

        public Mouse GetMouseByModelName(string modelName)
        {
            return _storeDbContext.Mice.SingleOrDefault(x => x.ModelName == modelName);
        }

        public List<Mouse> GetMouseByBrandName(string brandName)
        {
            return _storeDbContext.Mice.Where(x => x.BrandName == brandName).ToList();
        }
    }
}
