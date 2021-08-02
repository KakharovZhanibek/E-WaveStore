using E_WaveStore.DataLayer.Models.Entity;
using E_WaveStore.DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Repositories.Implementations
{
    public class SpecificationRepository : BaseRepository<Specification>, ISpecificationRepository
    {
        public SpecificationRepository(ApplicationContext storeDbContext) : base(storeDbContext) { }

    }
}
