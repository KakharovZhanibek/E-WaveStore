using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using E_WaveStore.DataLayer;
using E_WaveStore.DataLayer.Entity;
using E_WaveStore.DataLayer.Models;
using E_WaveStore.DataLayer.Repositories.Implementations;
using E_WaveStore.DataLayer.Repositories.Interfaces;
using E_WaveStore.Models;
using E_WaveStore.PresentationLayer.Implementations;
using E_WaveStore.PresentationLayer.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace E_WaveStore
{
    public class Startup
    {
        // public const string AuthMethod = "TestCookie";
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //services.AddOpenApiDocument();
            services.AddRazorPages()
                 .AddRazorRuntimeCompilation();

            // var connectionString = Configuration.GetValue<string>("SpecialConnectionStrings");
            //services.AddDbContext<StoreDbContext>(option => option.UseSqlServer(connectionString));
            services.AddDbContext<ApplicationContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(opts =>
            {
                opts.Password.RequiredLength = 5;   // ??????????? ?????
                opts.Password.RequireNonAlphanumeric = false;   // ????????? ?? ?? ?????????-???????? ???????
                opts.Password.RequireLowercase = false; // ????????? ?? ??????? ? ?????? ????????
                opts.Password.RequireUppercase = false; // ????????? ?? ??????? ? ??????? ????????
                opts.Password.RequireDigit = false; // ????????? ?? ?????
                opts.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationContext>();


            RegisterRepositories(services);

            /* services.AddScoped<ICategoryRepository, CategoryRepository>();
             services.AddScoped<IPhoneRepository, PhoneRepository>();*/

            services.AddScoped<IKeyboardPresentation, KeyboardPresentation>();

            RegisterAutoMapper(services);

            /* services.AddAuthentication(AuthMethod)
                 .AddCookie(AuthMethod, config =>
                 {
                     config.Cookie.Name = "TestCookie";
                     config.LoginPath = "/User/Login";
                     config.AccessDeniedPath = "/User/Login";
                 });*/

            services.AddHttpContextAccessor();
        }
        private void RegisterRepositories(IServiceCollection services)
        {
            IEnumerable<Type> implementationsType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(type =>
                        !type.IsInterface && type.GetInterface(typeof(IBaseRepository<>).Name) != null);

            foreach (Type implementationType in implementationsType)
            {
                IEnumerable<Type> servicesType = implementationType
                    .GetInterfaces()
                    .Where(r => !r.Name.Contains(typeof(IBaseRepository<>).Name));

                foreach (Type serviceType in servicesType)
                {
                    services.AddScoped(serviceType, implementationType);
                }
            }
        }

        private void RegisterAutoMapper(IServiceCollection services)
        {
            var configurationExp = new MapperConfigurationExpression();

            MapBothSide<Keyboard, KeyboardVM>(configurationExp);

            var config = new MapperConfiguration(configurationExp);
            var mapper = new Mapper(config);
            services.AddScoped<IMapper>(x => mapper);
        }

        public void MapBothSide<Type1, Type2>(MapperConfigurationExpression configurationExp)
        {
            configurationExp.CreateMap<Type1, Type2>();
            configurationExp.CreateMap<Type2, Type1>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
