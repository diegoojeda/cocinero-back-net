using ElCocineroBack.Domain.ValueObjects;

namespace ElCocineroBack.Domain.Ingredient
{
    public class IngredientId: Identity
    {
        public IngredientId()
        {
        }

        public IngredientId(string id) : base(id)
        {
        }
    }
}