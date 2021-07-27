using E_WaveStore.DataLayer.Entity;
using E_WaveStore.DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E_WaveStore.DataLayer.Repositories.Implementations
{
    public class MonitorRepository : BaseRepository<Monitor>, IMonitorRepository
    {
        public MonitorRepository(StoreDbContext storeDbContext) : base(storeDbContext) { }

        public Monitor GetMonitorByModelName(string modelName)
        {
            return _storeDbContext.Monitors.SingleOrDefault(x => x.ModelName == modelName);
        }

        public List<Monitor> GetMonitorByBrandName(string brandName)
        {
            return _storeDbContext.Monitors.Where(x => x.BrandName == brandName).ToList();
        }
    }
}
