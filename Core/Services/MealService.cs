using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataContext.Data;
using DataContext.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class MealService
    {
        private readonly CaloriesContext _context;

        public MealService(CaloriesContext context)
        {
            _context = context;
        }

        public Task<List<Meal>> GetMealsAsync()
        {
            return _context.Meals
                .Include(x => x.Recipes)
                .ToListAsync();
        }

        public IEnumerable<Recipe> GetRecipesForMealIdAsync(int mealId)
        {
            return _context.Meals
                .Include(x => x.Recipes)
                .Single(m => m.Id == mealId).Recipes
                .ToList();
        }

        public Task<Recipe> AddRecipeToMealAsync(int recipeId, int mealId)
        {
            Recipe recipe = _context.Recipes.Single(r => r.Id == recipeId);
            Meal meal = _context.Meals.Single(r => r.Id == mealId);
            recipe.Meal = meal;
            _context.Recipes.Update(recipe);
            _context.SaveChanges();
            return _context.Recipes.SingleAsync(r => r.Id == recipeId);
        }
    }
}