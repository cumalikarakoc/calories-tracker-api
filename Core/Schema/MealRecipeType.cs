using System.Collections.Generic;
using Core.Schema.Dtos;
using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema
{
    public class MealRecipeType : ObjectGraphType<MealRecipeDto>
    {
        public MealRecipeType()
        {
            Field(r => r.Id);
            Field(r => r.Name);
            Field<ListGraphType<IngredientRecipeType>, IEnumerable<IngredientRecipe>>()
                .Name("ingredients")
                .Resolve(context => context.Source.Ingredients);
            Field(x => x.CreatedAt);
        }
    }
}