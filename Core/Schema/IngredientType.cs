using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema
{
    public class IngredientType : ObjectGraphType<Ingredient>
    {
        public IngredientType()
        {
            Field(i => i.Id);
            Field(i => i.Name);
            Field(i => i.Calories);
        }
    }
}