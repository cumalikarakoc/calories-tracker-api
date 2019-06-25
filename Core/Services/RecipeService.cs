using System.Collections.Generic;
using System.Threading.Tasks;
using DataContext.Data;
using DataContext.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class RecipeService
    {
        private readonly CaloriesContext _context;

        public RecipeService(CaloriesContext context)
        {
            _context = context;
        }

        public Task<List<Recipe>> GetRecipesAsync()
        {
            return _context.Recipes
                .Include(r => r.Meal)
                .ToListAsync();
        }
        
        public Task<Recipe> CreateAsync(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            _context.SaveChangesAsync();

            return _context.Recipes
                .Include(m => m.Meal)
                .SingleAsync(m => m.Id == recipe.Id);
        }
    }
}