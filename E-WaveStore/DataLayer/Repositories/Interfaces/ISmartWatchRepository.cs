using E_WaveStore.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Repositories.Interfaces
{
    public interface ISmartWatchRepository : IBaseRepository<SmartWatch>
    {
        SmartWatch GetSmartWatchByModelName(string modelName);
        List<SmartWatch> GetSmartWatchByBrandName(string brandName);
    }
}
