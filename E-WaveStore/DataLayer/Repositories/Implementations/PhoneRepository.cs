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
        public PhoneRepository(ApplicationContext storeDbContext) : base(storeDbContext) { }

    }
}
