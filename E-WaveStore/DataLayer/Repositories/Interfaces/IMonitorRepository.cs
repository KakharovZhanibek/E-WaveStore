using E_WaveStore.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Repositories.Interfaces
{
    public interface IMonitorRepository : IBaseRepository<Monitor>
    {
        Monitor GetMonitorByModelName(string modelName);
        List<Monitor> GetMonitorByBrandName(string brandName);
    }
}
