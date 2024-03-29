using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataContext.Data;
using DataContext.Models;
using GraphQL;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

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
                .ToListAsync();
        }
        
        public Task<Meal> CreateAsync(Meal meal)
        {
            _context.Meals.Add(meal);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                if (!(e.InnerException is MySqlException exception)) throw;
                
                if (exception.Number == (int) MySqlErrorCode.DuplicateKeyEntry)
                {
                    throw new ExecutionError(meal.Name + " exists already in the database.");
                }
                throw;
            }

            return Task.FromResult(meal);
        }

        public Task<Meal> RemoveAsync(int id)
        {
            var meal = _context.Meals.Single(m => m.Id == id);
            _context.Meals.Remove(meal);
            _context.SaveChanges();

            return Task.FromResult(meal);
        }
    }
}