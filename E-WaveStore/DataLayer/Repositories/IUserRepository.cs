using E_WaveStore.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer.Repositories
{
    public interface IUserRepository
    {
        UserDb Get(long id);
        UserDb GetByName(string email);
        UserDb Login(string email, string password);
        UserDb Save(UserDb model);
    }
}
