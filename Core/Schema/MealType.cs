using System.Collections.Generic;
using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema
{
    public class MealType : ObjectGraphType<Meal>
    {
        public MealType()
        {
            Field(m => m.Id);
            Field(m => m.Name);
            Field<ListGraphType<MealRecipeType>,  IEnumerable<MealRecipe>>()
                .Name("recipes")
                .Resolve(context => context.Source.Recipes);
        }
    }
}