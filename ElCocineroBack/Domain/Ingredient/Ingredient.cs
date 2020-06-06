using ElCocineroBack.Controllers;
using ElCocineroBack.Domain.ValueObjects;

namespace ElCocineroBack.Domain.Ingredient
{
    using IngredientName = NonNullString;

    public class Ingredient
    {
        public IngredientId Id => new IngredientId(State.IngredientKey);
        public IngredientName Name => new IngredientName(State.Name);

        public IngredientState State { get; }

        public Ingredient(IngredientId id, IngredientName name)
        {
            State = new IngredientState
            {
                IngredientKey = id.Id,
                Name = name
            };
        }

        public Ingredient(IngredientState state)
        {
            State = state;
        }

        public static implicit operator IngredientResponseDto(Ingredient ingredient)
        {
            return new IngredientResponseDto
            {
                Id = ingredient.Id.Id,
                Name = ingredient.Name
            };
        }

        public static implicit operator Ingredient(CreateIngredientDto ingredient)
        {
            return new Ingredient(new IngredientId(), ingredient.Name);
        }
    }
}