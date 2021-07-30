using E_WaveStore.DataLayer.Entity;
using E_WaveStore.DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Repositories.Implementations
{
    public class MouseRepository : BaseRepository<Mouse>, IMouseRepository
    {
        public MouseRepository(ApplicationContext storeDbContext) : base(storeDbContext) { }

    }
}
