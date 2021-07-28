using E_WaveStore.DataLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected StoreDbContext _storeDbContext;

        public UserRepository(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }
        public UserDb Get(long id)
        {
            return _storeDbContext.UserDbs.SingleOrDefault(x => x.Id == id);
        }
        public UserDb GetByName(string email)
        {
            return _storeDbContext.UserDbs.SingleOrDefault(x => x.Email == email);
        }

        public UserDb Login(string email, string password)
        {
            return _storeDbContext.UserDbs
               .SingleOrDefault(x => x.Email == email && x.Password == password);
        }

        public UserDb Save(UserDb model)
        {
            if (model.Id > 0)
            {
                //_dbSet.Update(model);
                _storeDbContext.Entry(model).State = EntityState.Modified;
            }
            else
            {
                _storeDbContext.UserDbs.Add(model);
            }

            _storeDbContext.SaveChanges();

            return model;
        }
    }
}
