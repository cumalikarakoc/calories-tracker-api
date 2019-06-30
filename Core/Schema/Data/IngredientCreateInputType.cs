using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema.Data
{
    public class IngredientCreateInputType : InputObjectGraphType<Ingredient>
    {
        public IngredientCreateInputType()
        {
            Name = "ingredientInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<IntGraphType>>("calories");
        }
    }
}