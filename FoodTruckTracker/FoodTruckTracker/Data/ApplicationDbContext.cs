using FoodTruckTracker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodTruckTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<FoodTruck> FoodTrucks { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MenuItem>()
                .Property(m => m.Price)
                .HasColumnType("decimal(18,2)"); // Specify precision and scale

            // Continue with other configurations
        }
    }
}
