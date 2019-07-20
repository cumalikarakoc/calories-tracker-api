using Core.Schema.Dtos;
using GraphQL.Types;

namespace Core.Schema
{
    public class IngredientRecipeType : ObjectGraphType<IngredientRecipeDto>
    {
        public IngredientRecipeType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Calories);
            Field(x => x.Quantity);
        }
    }
}