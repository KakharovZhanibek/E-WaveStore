using E_WaveStore.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Repositories.Interfaces
{
    public interface IMonoblockRepository : IBaseRepository<MonoBlock>
    {
        MonoBlock GetPhoneByModelName(string modelName);
        List<MonoBlock> GetPhoneByBrandName(string brandName);
    }
}
