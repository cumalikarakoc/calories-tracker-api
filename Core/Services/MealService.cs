using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Schema.Dtos;
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

        public Task<List<MealDto>> GetMealsAsync(DateTime? createdAt)
        {
            if (!createdAt.HasValue)
            {
                return _context.Meals.Select(m => new MealDto(m))
                    .ToListAsync();
            }

            return _context.MealRecipe
                .Include(x => x.Recipe)
                .ThenInclude(x => x.Ingredients)
                .ThenInclude(x => x.Ingredient)
                .Where(x => x.CreatedAt.Date == createdAt.Value.Date)
                .GroupBy(x => x.MealId)
                .Select(mealRecipes => new MealDto
                {
                    Id = mealRecipes.First().Meal.Id,
                    Name = mealRecipes.First().Meal.Name,
                    Recipes = mealRecipes.Select(mr => new MealRecipeDto(mr.Recipe, mr.CreatedAt)).ToList()
                }).ToListAsync();
        }

        public Task<MealDto> AddRecipeToMealAsync(int recipeId, int mealId)
        {
            var meal = GetMealDecoratedWithRelations()
                .Single(m => m.Id == mealId);
            var recipe = _context.Recipes.Single(x => x.Id == recipeId);
            meal.Recipes.Add(new MealRecipe
            {
                RecipeId = recipeId, CreatedAt = DateTime.Now, MealId = mealId, Meal = meal, Recipe = recipe
            });
            _context.SaveChanges();

            return Task.FromResult(new MealDto(meal));
        }

        public Task<MealDto> RemoveRecipeFromMealAsync(int recipeId, int mealId, DateTime createdAt)
        {
            var meal = GetMealDecoratedWithRelations()
                .Single(m => m.Id == mealId);
            var recipe = meal.Recipes.Single(x => x.RecipeId == recipeId && x.CreatedAt.Date == createdAt.Date);
            meal.Recipes.Remove(recipe);
            _context.SaveChanges();

            return Task.FromResult(new MealDto(meal));
        }

        private IIncludableQueryable<Meal, Recipe> GetMealDecoratedWithRelations()
        {
            return _context.Meals
                .Include(m => m.Recipes)
                .ThenInclude(x => x.Recipe);
        }
    }
}