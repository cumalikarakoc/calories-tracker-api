using DataContext.Models;
using Microsoft.EntityFrameworkCore;

namespace DataContext.Data
{
    public class CaloriesContext : DbContext
    {
        public CaloriesContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Meal> Meals { get; set; }
        public DbSet<Consumable> Consumables { get; set; }
        public DbSet<Consumption> Consumptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meal>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Consumable>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Consumable>()
                .HasAlternateKey(i => i.Name)
                .HasName("AK_Consumable_Name");

            modelBuilder.Entity<Consumption>()
                .HasKey(c => c.Id);
        }
    }
}