using E_WaveStore.DataLayer.Entity;
using E_WaveStore.DataLayer.Models;
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
        public DbSet<Keyboard> Keyboards { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Monitor> Monitors { get; set; }
        public DbSet<MonoBlock> MonoBlocks { get; set; }
        public DbSet<Mouse> Mice { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<SmartWatch> SmartWatches { get; set; }
        public DbSet<Tv> Tvs { get; set; }
    }
    /* public class StoreDbContext : DbContext
     {
         public DbSet<Category> Categories { get; set; }
         public DbSet<Keyboard> Keyboards{ get; set; }
         public DbSet<Laptop> Laptops{ get; set; }
         public DbSet<Monitor> Monitors{ get; set; }
         public DbSet<MonoBlock> MonoBlocks{ get; set; }
         public DbSet<Mouse> Mice{ get; set; }
         public DbSet<Phone> Phones{ get; set; }
         public DbSet<SmartWatch> SmartWatches{ get; set; }
         public DbSet<Tv> Tvs{ get; set; }



         public StoreDbContext(DbContextOptions options) : base(options) { }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             *//* modelBuilder.Entity<Citizen>()
                  .HasOne(x => x.House)
                  .WithMany(x => x.Citizens);

              modelBuilder.Entity<School>()
                       .HasIndex(u => u.Name)
                       .IsUnique();         

              modelBuilder.Entity<Policeman>()
                  .HasMany(v => v.Violations)
                  .WithOne(v => v.Policeman)
                  .OnDelete(DeleteBehavior.Cascade);*//*


             base.OnModelCreating(modelBuilder);
         }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             // optionsBuilder.UseLazyLoadingProxies();
             base.OnConfiguring(optionsBuilder);
         }

     }*/
}
