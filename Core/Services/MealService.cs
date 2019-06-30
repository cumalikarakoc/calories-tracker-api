using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataContext.Data;
using DataContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Services
{
    public class MealService
    {
        private readonly CaloriesContext _context;

        public MealService(CaloriesContext context)
        {
            _context = context;
        }

        public Task<Meal> GetRecipesForMealIdAsync(int mealId)
        {
            return GetMealDecoratedWithRelations()
                .SingleAsync(m => m.Id == mealId);
        }

        public Task<Meal> AddRecipeToMealAsync(int recipeId, int mealId)
        {
            var meal = _context.Meals.Single(r => r.Id == mealId);
            meal.Recipes.Add(new MealRecipe
            {
                RecipeId = recipeId,
                CreatedAt = DateTime.Now
            });
            _context.SaveChanges();

            return GetMealDecoratedWithRelations()
                .SingleAsync(m => m.Id == meal.Id);
        }

        private IIncludableQueryable<Meal, Recipe> GetMealDecoratedWithRelations()
        {
            return _context.Meals
                .Include(m => m.Recipes)
                .ThenInclude(x => x.Recipe);
        }
    }
}