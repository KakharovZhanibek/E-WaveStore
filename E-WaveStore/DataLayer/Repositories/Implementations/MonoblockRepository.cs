using E_WaveStore.DataLayer.Entity;
using E_WaveStore.DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Repositories.Implementations
{
    public class MonoblockRepository : BaseRepository<MonoBlock>, IMonoblockRepository
    {
        public MonoblockRepository(StoreDbContext storeDbContext) : base(storeDbContext) { }

        public MonoBlock GetPhoneByModelName(string modelName)
        {
            return _storeDbContext.MonoBlocks.SingleOrDefault(x => x.ModelName == modelName);
        }

        public List<MonoBlock> GetPhoneByBrandName(string brandName)
        {
            return _storeDbContext.MonoBlocks.Where(x => x.BrandName == brandName).ToList();
        }
    }
}
