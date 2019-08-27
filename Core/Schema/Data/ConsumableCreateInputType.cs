using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema.Data
{
    public class ConsumableCreateInputType : InputObjectGraphType<Consumable>
    {
        public ConsumableCreateInputType()
        {
            Name = "consumableInput";
            
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<IntGraphType>>("calories");
            Field<NonNullGraphType<StringGraphType>>("description");
        }
    }
}