using System.Collections.Generic;
using System.Linq;
using Core.Services;
using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema
{
    public class MealType : ObjectGraphType<Meal>
    {
        public MealType(MealService mealService)
        {
            Field(m => m.Id);
            Field(m => m.Name);
            Field<ListGraphType<RecipeType>, IEnumerable<Recipe>>()
                .Name("recipes")
                .Resolve(context => mealService.GetRecipesForMealIdAsync(context.Source.Id));
        }
    }
}