
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Interfaces
{
    public interface IBaseRepository<DbModel> where DbModel : BaseModel
    {
        DbModel Get(long id);
        List<DbModel> GetAll();
        void Remove(DbModel model);
        DbModel Save(DbModel model);
        IQueryable<DbModel> GetAllAsIQueryable();
    }
}
