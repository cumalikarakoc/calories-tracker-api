using Core.Services;
using GraphQL.Types;

namespace Core.Schema
{
    public class SchemaQuery : ObjectGraphType<object>
    {
        public SchemaQuery(RecipeService recipeService)
        {
            Name = "Query";
            Field<ListGraphType<RecipeType>>(
                "recipes",
                resolve: context => recipeService.GetRecipesAsync()
            );
        }
    }
}