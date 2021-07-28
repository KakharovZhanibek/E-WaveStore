using E_WaveStore.DataLayer.Entity;
using E_WaveStore.DataLayer.Repositories;
using E_WaveStore.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace E_WaveStore.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public UserService(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public UserDb GetUser()
        {            
            var idStr = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(x => x.Type == "Id")?.Value;
            if (string.IsNullOrEmpty(idStr))
            {
                return null;
            }

            var id = int.Parse(idStr);
            return _userRepository.Get(id);
        }

        public ClaimsPrincipal GetClaimsPrincipal(UserDb user)
        {
            var pages = new List<Claim>() {
                new Claim("Id", user.Id.ToString()),
                new Claim("Email", user.Email.ToString()),
                new Claim(ClaimTypes.AuthenticationMethod, Startup.AuthMethod)
            };

            var claimsIdenity = new ClaimsIdentity(pages, Startup.AuthMethod);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdenity);
            return claimsPrincipal;
        }

        public void Save(RegisterVM viewModel)
        {
            var userDb = new UserDb()
            {
                Username = viewModel.Username,
                Email = viewModel.Email,
                Password = viewModel.Password                
            };

            _userRepository.Save(userDb);
        }
    }
}
