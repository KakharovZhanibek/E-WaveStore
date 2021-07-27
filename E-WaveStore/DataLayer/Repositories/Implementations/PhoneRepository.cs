using E_WaveStore.DataLayer.Repositories.Interfaces;
using E_WaveStore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Repositories.Implementations
{
    public class PhoneRepository : BaseRepository<Phone>, IPhoneRepository
    {
        public PhoneRepository(StoreDbContext storeDbContext) : base(storeDbContext) { }

        public Phone GetPhoneByModelName(string modelName)
        {
            return _storeDbContext.Phones.SingleOrDefault(x => x.ModelName == modelName);
        }

        public List<Phone> GetPhoneByBrandName(string brandName)
        {
           return _storeDbContext.Phones.Where(x => x.BrandName == brandName).ToList();
        }
    }
}
