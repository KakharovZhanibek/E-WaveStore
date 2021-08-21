using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Repositories.Implementations;
using DataLayer.Repositories.Interfaces;
using E_WaveStore.Models;
using E_WaveStore.Models.ViewModels;
using E_WaveStore.PresentationLayer.Implementations;
using E_WaveStore.PresentationLayer.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            /*services.AddControllersWithViews().AddNewtonsoftJson();*/
            services.AddControllersWithViews(options =>
            {
                options.CacheProfiles.Add("Caching",
                    new CacheProfile()
                    {
                        Duration = 300
                    });
                options.CacheProfiles.Add("NoCaching",
                    new CacheProfile()
                    {
                        Location = ResponseCacheLocation.None,
                        NoStore = true
                    });
            }).AddNewtonsoftJson();

            services.AddRazorPages()
                 .AddRazorRuntimeCompilation();
            services.AddDbContext<ApplicationContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("E-WaveStore")),
             ServiceLifetime.Transient);

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
            
            services.AddScoped<ICategoryPresentation, CategoryPresentation>();
            services.AddScoped<IProductPresentation, ProductPresentation>();
            services.AddScoped<ICartPresentation, CartPresentation>();
            services.AddScoped<IOrderPresentation, OrderPresentation>();
            //services.AddScoped<IPaymentTypePresentation, PaymentTypePresentation>();

            /*  services.AddScoped<IKeyboardPresentation, KeyboardPresentation>();                       
              services.AddScoped<ILaptopPresentation, LaptopPresentation>();
              services.AddScoped<IMonitorPresentation, MonitorPresentation>();
              services.AddScoped<IMonoblockPresentation, MonoblockPresentation>();
              services.AddScoped<IMousePresentation, MousePresentation>();*/

            /* services.AddScoped<IPhonePresentation, PhonePresentation>();
             services.AddScoped<ISmartWatchPresentation, SmartWatchPresentation>();
             services.AddScoped<ITvPresentation, TvPresentation>();*/

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
            /* IEnumerable<Type> implementationsType = Assembly
                 .GetExecutingAssembly()
                 .GetTypes()
                 .Where(type =>
                         !type.IsInterface && type.GetInterface(typeof(IBaseRepository<>).Name) != null);*/

            IEnumerable<Type> implementationsType = Assembly
               .Load("DataLayer")
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

            MapBothSide<Category, CategoryVM>(configurationExp);
            MapBothSide<Product, ProductVM>(configurationExp);
            MapBothSide<Product, KeyboardVM>(configurationExp);
            MapBothSide<Product, LaptopVM>(configurationExp);
            MapBothSide<Product, MonitorVM>(configurationExp);
            MapBothSide<Product, MonoBlockVM>(configurationExp);
            MapBothSide<Product, MouseVM>(configurationExp);
            MapBothSide<Product, PhoneVm>(configurationExp);
            MapBothSide<Product, SmartWatchVM>(configurationExp);
            MapBothSide<Product, TvVM>(configurationExp);
            MapBothSide<Cart, CartVM>(configurationExp);
            MapBothSide<Order, OrderVM>(configurationExp);
            MapBothSide<PaymentType, PaymentTypeVM>(configurationExp);

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
            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Add("Cache-Control", "public,max-age=600");
                }
            });

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
