using E_WaveStore.DataLayer.Entity;
using E_WaveStore.DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Repositories.Implementations
{
    public class KeyboardRepository : BaseRepository<Keyboard>, IKeyboardRepository
    {
        public KeyboardRepository(StoreDbContext storeDbContext) : base(storeDbContext) { }

        public Keyboard GetKeyboardByModelName(string modelName)
        {
            return _storeDbContext.Keyboards.SingleOrDefault(x => x.ModelName == modelName);
        }

        public List<Keyboard> GetKeyboardByBrandName(string brandName)
        {
            return _storeDbContext.Keyboards.Where(x => x.BrandName == brandName).ToList();
        }
    }
}
