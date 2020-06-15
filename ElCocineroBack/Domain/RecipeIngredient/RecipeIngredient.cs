using ElCocineroBack.Controllers.Recipe.Response;
using ElCocineroBack.Domain.Ingredient;
using ElCocineroBack.Domain.Recipe;
using ElCocineroBack.Domain.ValueObjects;

namespace ElCocineroBack.Domain.RecipeIngredient
{
    using Amount = PositiveInteger;
    using IngredientUnit = NonNullString;

    public class RecipeIngredient
    {
        private Amount Amount => State.Amount;
        private IngredientUnit Unit => State.Unit;

        public RecipeIngredientState State;

        public RecipeIngredient(
            RecipeId recipeId,
            IngredientId ingredientId,
            PositiveInteger amount,
            IngredientUnit unit)
        {
            State = new RecipeIngredientState
            {
                RecipeId = recipeId.Id,
                IngredientId = ingredientId.Id,
                Amount = amount.Value,
                Unit = unit
            };
        }

        public RecipeIngredient(RecipeIngredientState state)
        {
            State = state;
        }

        public static implicit operator RecipeIngredientResponseDto(RecipeIngredient recipeIngredient)
        {
            return new RecipeIngredientResponseDto
            {
                IngredientId = recipeIngredient.State.IngredientId,
                Amount = recipeIngredient.Amount,
                Unit = recipeIngredient.Unit
            };
        }
    }
}