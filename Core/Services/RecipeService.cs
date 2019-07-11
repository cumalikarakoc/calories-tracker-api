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

        public object GetRecipeByIdAsync(int recipeId)
        {
            return GetRecipeDecoratedWithRelations()
                .SingleAsync(r => r.Id == recipeId);
        }

        public Task<Recipe> CreateAsync(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            _context.SaveChangesAsync();

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

        public Task<Recipe> RemoveAsync(int recipeId)
        {
            var recipe = _context.Recipes.Single(r => r.Id == recipeId);
            _context.Recipes.Remove(recipe);
            _context.SaveChanges();

            return Task.FromResult(recipe);
        }

        public Task<Recipe> AddIngredientAsync(IngredientRecipe ingredientRecipe)
        {
            var recipe = GetRecipeDecoratedWithRelations()
                .Single(r => r.Id == ingredientRecipe.RecipeId);
            recipe.Ingredients.Add(ingredientRecipe);
            _context.SaveChanges();

            return GetRecipeDecoratedWithRelations()
                .SingleAsync(r => r.Id == recipe.Id);
        }

        public Task<Recipe> RemoveIngredientAsync(int recipeId, int ingredientId)
        {
            var recipe = GetRecipeDecoratedWithRelations()
                .Single(r => r.Id == recipeId);

            var ingredient = recipe.Ingredients
                .Single(x => x.IngredientId == ingredientId);

            recipe.Ingredients.Remove(ingredient);
            _context.SaveChanges();

            return Task.FromResult(recipe);
        }
        
        public Task<Recipe> UpdateIngredientQuantityAsync(IngredientRecipe ingredientRecipe)
        {
            var recipe = GetRecipeDecoratedWithRelations()
                .Single(r => r.Id == ingredientRecipe.RecipeId);
            var ingredient = recipe.Ingredients
                .Single(x => x.IngredientId == ingredientRecipe.IngredientId);

            ingredient.Quantity = ingredientRecipe.Quantity;
            _context.SaveChanges();

            return GetRecipeDecoratedWithRelations()
                .SingleAsync(r => r.Id == recipe.Id);
        }

        private IIncludableQueryable<Recipe, Ingredient> GetRecipeDecoratedWithRelations()
        {
            return _context.Recipes
                .Include(r => r.Ingredients)
                .ThenInclude(x => x.Ingredient);
        }
    }
}