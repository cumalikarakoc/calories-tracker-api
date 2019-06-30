using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataContext.Data;
using DataContext.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class IngredientService
    {
        private readonly CaloriesContext _context;

        public IngredientService(CaloriesContext context)
        {
            _context = context;
        }

        public Task<List<Ingredient>> GetIngredientsAsync()
        {
            return _context.Ingredients
                .ToListAsync();
        }

        public Task<Ingredient> GetIngredientByIdAsync(int ingredientId)
        {
            return _context.Ingredients
                .SingleAsync(i => i.Id == ingredientId);
        }

        public Task<Ingredient> CreateAsync(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            _context.SaveChanges();

            return Task.FromResult(ingredient);
        }

        public Task<Ingredient> UpdateAsync(int ingredientId, Ingredient ingredient)
        {
            var ingredientToUpdate = _context.Ingredients
                .Single(i => i.Id == ingredientId);
            ingredientToUpdate.Name = ingredient.Name;
            ingredientToUpdate.Calories = ingredient.Calories;
            _context.SaveChanges();

            return Task.FromResult(ingredientToUpdate);
        }

        public Task<Ingredient> RemoveAsync(int ingredientId)
        {
            var ingredient = _context.Ingredients.Single(i => i.Id == ingredientId);
            _context.Ingredients.Remove(ingredient);
            _context.SaveChanges();
            
            return Task.FromResult(ingredient);
        }
    }
}