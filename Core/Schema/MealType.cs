using System.Collections.Generic;
using Core.Schema.Dtos;
using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema
{
    public class MealType : ObjectGraphType<MealDto>
    {
        public MealType()
        {
            Field(m => m.Id);
            Field(m => m.Name);
            Field<ListGraphType<MealRecipeType>,  IEnumerable<MealRecipeDto>>()
                .Name("recipes")
                .Resolve(context => context.Source.Recipes);
            Field<ListGraphType<IngredientMealType>,  IEnumerable<IngredientMeal>>()
                .Name("ingredients")
                .Resolve(context => context.Source.Ingredients);
        }
    }
}