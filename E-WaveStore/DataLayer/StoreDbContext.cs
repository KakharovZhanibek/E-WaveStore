using E_WaveStore.DataLayer.Entity;
using E_WaveStore.DataLayer.Models;
using E_WaveStore.DataLayer.Models.Entity;
using E_WaveStore.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            // Database.EnsureCreated();
            //Database.Migrate();
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            
            base.OnConfiguring(optionsBuilder);
        }
        /*public DbSet<Specification> Specifications { get; set; }*/
        /* public DbSet<Keyboard> Keyboards { get; set; }
         public DbSet<Laptop> Laptops { get; set; }
         public DbSet<Monitor> Monitors { get; set; }
         public DbSet<MonoBlock> MonoBlocks { get; set; }
         public DbSet<Mouse> Mice { get; set; }
         public DbSet<Phone> Phones { get; set; }
         public DbSet<SmartWatch> SmartWatches { get; set; }
         public DbSet<Tv> Tvs { get; set; }*/


    }
}
