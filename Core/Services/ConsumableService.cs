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
    public class ConsumableService
    {
        private readonly CaloriesContext _context;

        public ConsumableService(CaloriesContext context)
        {
            _context = context;
        }

        public Task<List<Consumable>> GetConsumablesAsync()
        {
            return _context.Consumables
                .ToListAsync();
        }

        public Task<Consumable> CreateAsync(Consumable consumable)
        {
            _context.Consumables.Add(consumable);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                if (!(e.InnerException is MySqlException exception)) throw;

                if (exception.Number == (int) MySqlErrorCode.DuplicateKeyEntry)
                {
                    throw new ExecutionError(consumable.Name + " exists already in the database.");
                }

                throw;
            }

            return Task.FromResult(consumable);
        }

        public Task<Consumable> UpdateAsync(int ingredientId, Consumable consumable)
        {
            var consumableToUpdate = _context.Consumables
                .Single(i => i.Id == ingredientId);
            consumableToUpdate.Name = consumable.Name;
            consumableToUpdate.Calories = consumable.Calories;
            consumableToUpdate.Description = consumable.Description;
            _context.SaveChanges();

            return Task.FromResult(consumableToUpdate);
        }

        public Task<Consumable> RemoveAsync(int ingredientId)
        {
            var consumable = _context.Consumables.Single(i => i.Id == ingredientId);
            _context.Consumables.Remove(consumable);
            _context.SaveChanges();

            return Task.FromResult(consumable);
        }
    }
}