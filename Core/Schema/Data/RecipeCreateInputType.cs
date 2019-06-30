using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema.Data
{
    public class RecipeCreateInputType : InputObjectGraphType<Recipe>
    {
        public RecipeCreateInputType()
        {
            Name = "RecipeInput";
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}