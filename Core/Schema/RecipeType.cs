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
        }
    }
}