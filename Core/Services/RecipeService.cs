using System.Collections.Generic;
using System.Linq;
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
                .Include(r => r.Ingredients)
                .ThenInclude(x => x.Ingredient)
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

        public Task<Recipe> AddIngredientAsync(int recipeId, int ingredientId)
        {
            var recipe = _context.Recipes
                .Include(r => r.Ingredients)
                .ThenInclude(x => x.Ingredient)
                .Single(r => r.Id == recipeId);
            recipe.Ingredients.Add(new IngredientRecipe
            {
                IngredientId = ingredientId, RecipeId = recipeId
            });
            _context.SaveChanges();

            return Task.FromResult(recipe);
        }
    }
}