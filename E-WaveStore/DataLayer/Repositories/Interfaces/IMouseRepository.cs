using E_WaveStore.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Repositories.Interfaces
{
    public interface IMouseRepository : IBaseRepository<Mouse>
    {
        Mouse GetMouseByModelName(string modelName);
        List<Mouse> GetMouseByBrandName(string brandName);
    }
}
