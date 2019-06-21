using Core.Schema.Data;
using Core.Services;
using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema
{
    public class SchemaMutation : ObjectGraphType<object>
    {
        public SchemaMutation(RecipeService recipeService)
        {
            Name = "Mutation";
            Field<RecipeType>(
                "createRecipe",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<RecipeCreateInputType>> {Name = "recipe"}),
                resolve: context =>
                {
                    var input = context.GetArgument<RecipeCreateInputType>("recipe");
                    var order = new Recipe {Name = input.Name};
                    return recipeService.CreateAsync(order);
                }
            );
        }
    }
}