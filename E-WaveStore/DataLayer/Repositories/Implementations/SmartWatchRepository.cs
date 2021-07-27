using E_WaveStore.DataLayer.Entity;
using E_WaveStore.DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Repositories.Implementations
{
    public class SmartWatchRepository : BaseRepository<SmartWatch>, ISmartWatchRepository 
    {
        public SmartWatchRepository(StoreDbContext storeDbContext) : base(storeDbContext) { }

        public SmartWatch GetSmartWatchByModelName(string modelName)
        {
            return _storeDbContext.SmartWatches.SingleOrDefault(x => x.ModelName == modelName);
        }

        public List<SmartWatch> GetSmartWatchByBrandName(string brandName)
        {
            return _storeDbContext.SmartWatches.Where(x => x.BrandName == brandName).ToList();
        }
    }
}
