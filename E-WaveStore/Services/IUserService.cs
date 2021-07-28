using E_WaveStore.DataLayer.Entity;
using E_WaveStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace E_WaveStore.Services
{
    public interface IUserService
    {
        UserDb GetUser();
        ClaimsPrincipal GetClaimsPrincipal(UserDb user);
        void Save(RegisterVM viewModel);
    }
}
