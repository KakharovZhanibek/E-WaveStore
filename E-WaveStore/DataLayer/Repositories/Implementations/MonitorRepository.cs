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

    }
}
