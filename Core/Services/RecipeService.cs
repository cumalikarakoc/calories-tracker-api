using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataContext.Data;
using DataContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

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
            return GetRecipeDecoratedWithRelations()
                .ToListAsync();
        }

        public Task<Recipe> CreateAsync(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            _context.SaveChangesAsync();

            return GetRecipeDecoratedWithRelations()
                .SingleAsync(r => r.Id == recipe.Id);
        }

        public Task<Recipe> AddIngredientAsync(int recipeId, int ingredientId)
        {
            var recipe = GetRecipeDecoratedWithRelations()
                .Single(r => r.Id == recipeId);
            recipe.Ingredients.Add(new IngredientRecipe
            {
                IngredientId = ingredientId, RecipeId = recipeId
            });
            _context.SaveChanges();

            return GetRecipeDecoratedWithRelations()
                .SingleAsync(r => r.Id == recipe.Id);
        }

        public Task<Recipe> UpdateAsync(int recipeId, Recipe recipe)
        {
            var recipeToUpdate = GetRecipeDecoratedWithRelations()
                .Single(r => r.Id == recipeId);

            recipeToUpdate.Name = recipe.Name;
            _context.SaveChanges();

            return Task.FromResult(recipeToUpdate);
        }

        private IIncludableQueryable<Recipe, Ingredient> GetRecipeDecoratedWithRelations()
        {
            return _context.Recipes
                .Include(r => r.Ingredients)
                .ThenInclude(x => x.Ingredient);
        }
    }
}