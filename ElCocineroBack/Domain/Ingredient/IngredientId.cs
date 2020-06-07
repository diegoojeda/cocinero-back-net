using ElCocineroBack.Domain.ValueObjects;

namespace ElCocineroBack.Domain.Ingredient
{
    public class IngredientId : Identity
    {
        public IngredientId()
        {
        }

        public IngredientId(string id) : base(id)
        {
        }

        public static implicit operator IngredientId(string value)
        {
            return new IngredientId(value);
        }

        public static implicit operator string(IngredientId value)
        {
            return value.Id;
        }
    }
}