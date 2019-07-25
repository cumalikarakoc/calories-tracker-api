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
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<MealRecipe> MealRecipe { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meal>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Recipe>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Recipe>()
                .HasAlternateKey(r => r.Name)
                .HasName("AK_Recipe_Name");

            modelBuilder.Entity<Ingredient>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Ingredient>()
                .HasAlternateKey(i => i.Name)
                .HasName("AK_Ingredient_Name");

            modelBuilder.Entity<IngredientRecipe>()
                .HasKey(i => new {i.IngredientId, i.RecipeId});

            modelBuilder.Entity<MealRecipe>()
                .HasKey(mr => new {mr.RecipeId, mr.CreatedAt});

            modelBuilder.Entity<IngredientMeal>()
                .HasKey(im => new {im.IngredientId, im.CreatedAt});
        }
    }
}