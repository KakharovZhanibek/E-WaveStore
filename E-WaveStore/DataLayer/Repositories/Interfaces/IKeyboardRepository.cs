using E_WaveStore.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Repositories.Interfaces
{
    public interface IKeyboardRepository : IBaseRepository<Keyboard>
    {
        Keyboard GetKeyboardByModelName(string modelName);
        List<Keyboard> GetKeyboardByBrandName(string brandName);
    }
}
