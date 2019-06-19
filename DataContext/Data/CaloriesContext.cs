using DataContext.Models;
using Microsoft.EntityFrameworkCore;

namespace DataContext.Data
{
    public class CaloriesContext : DbContext
    {
        public CaloriesContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Ingredient>()
                .HasKey(i => i.Id);
        }
    }
}