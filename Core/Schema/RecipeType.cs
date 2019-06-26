using System.Linq;
using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema
{
    public class RecipeType : ObjectGraphType<Recipe>
    {
        public RecipeType()
        {
            Field(r => r.Id);
            Field(r => r.Name);
            Field<MealType>("meal", resolve: context => context.Source.Meal);
            Field<ListGraphType<IngredientType>>("ingredients", resolve: context => context.Source.Ingredients.Select(x => x.Ingredient));
        }
    }
}