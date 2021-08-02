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
using Microsoft.OpenApi.Models;

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
            services.AddControllersWithViews().AddNewtonsoftJson();

            services.AddRazorPages()
                 .AddRazorRuntimeCompilation();

            services.AddDbContext<ApplicationContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(opts =>
            {
                opts.Password.RequiredLength = 5;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
                opts.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationContext>();


            RegisterRepositories(services);

            //services.AddScoped<IKeyboardPresentation, KeyboardPresentation>();
  
            RegisterAutoMapper(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "E-WaveStore",
                    Description = "A simple example ASP.NET Core Web API",                   
                });
            });

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

            //MapBothSide<Category, CategoryVM>(configurationExp);
            MapBothSide<Keyboard, KeyboardVM>(configurationExp);
            /*MapBothSide<Laptop, LaptopVM>(configurationExp);
            MapBothSide<Monitor, MonitorVM>(configurationExp);
            MapBothSide<MonoBlock, MonoBlockVM>(configurationExp);
            MapBothSide<Mouse, MouseVM>(configurationExp);
            MapBothSide<Phone, PhoneVm>(configurationExp);
            MapBothSide<SmartWatch, SmartWatchVM>(configurationExp);
            MapBothSide<Tv, TvVM>(configurationExp);*/

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
                app.UseSwagger();
               
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "E-WaveStore");
                    //c.RoutePrefix = string.Empty;
                });
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
