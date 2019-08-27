using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataContext.Data;
using DataContext.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class ConsumptionService
    {
        private readonly CaloriesContext _context;

        public ConsumptionService(CaloriesContext context)
        {
            _context = context;
        }

        public Task<List<Consumption>> GetConsumptionsAsync(DateTime? createdAt)
        {
            if (!createdAt.HasValue || createdAt.Value.Date == new DateTime(1, 1, 1))
            {
                return _context.Consumptions
                .Include(x => x.Consumable)
                .Include(x => x.Meal)
                .ToListAsync();
            }

            return _context.Consumptions
                .Include(x => x.Consumable)
                .Include(x => x.Meal)
                .Where(r => r.CreatedAt.Date == createdAt.Value.Date)
                .ToListAsync();
        }

        public Task<Consumption> CreateAsync(int consumableId, int mealId)
        {
            var meal = _context.Meals
                .Single(m => m.Id == mealId);
            var consumable = _context.Consumables
                .Single(x => x.Id == consumableId);
            var consumption = new Consumption
            {
                MealId = mealId, Meal = meal, ConsumableId = consumableId, Consumable = consumable,
                CreatedAt = DateTime.Now
            };

            _context.Consumptions
                .Add(consumption);
            _context.SaveChanges();

            return Task.FromResult(consumption);
        }

        public Task<Consumption> RemoveAsync(int consumptionId)
        {
            var consumption = _context.Consumptions
                .Single(c => c.Id == consumptionId);

            _context.Consumptions
                .Remove(consumption);
            _context.SaveChanges();

            return Task.FromResult(consumption);
        }
    }
}