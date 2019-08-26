using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema
{
    public class ConsumableType : ObjectGraphType<Consumable>
    {
        public ConsumableType()
        {
            Field(c => c.Id);
            Field(c => c.Name);
            Field(c => c.Calories);
            Field(c => c.Description);
        }
    }
}