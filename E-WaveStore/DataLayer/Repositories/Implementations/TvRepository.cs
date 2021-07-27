using E_WaveStore.DataLayer.Entity;
using E_WaveStore.DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Repositories.Implementations
{
    public class TvRepository : BaseRepository<Tv>, ITvRepository
    {
        public TvRepository(StoreDbContext storeDbContext) : base(storeDbContext) { }

        public Tv GetTvByModelName(string modelName)
        {
            return _storeDbContext.Tvs.SingleOrDefault(x => x.ModelName == modelName);
        }

        public List<Tv> GettvByBrandName(string brandName)
        {
            return _storeDbContext.Tvs.Where(x => x.BrandName == brandName).ToList();
        }
    }
}
