using ElCocineroBack.Controllers.Recipe.Request;
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
        private RecipeId RecipeId => State.RecipeId;
        private IngredientId IngredientId => State.IngredientId;
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

        public static RecipeIngredient FromDto(RecipeIngredientDto dto, RecipeId recipeId)
        {
            return new RecipeIngredient(recipeId, dto.Id, dto.Amount, dto.Unit);
        }

        public static implicit operator RecipeIngredientResponseDto(RecipeIngredient recipeIngredient)
        {
            return new RecipeIngredientResponseDto
            {
                Ingredient = recipeIngredient.State.Ingredient.ToIngredient(),
                Amount = recipeIngredient.Amount,
                Unit = recipeIngredient.Unit,
            };
        }
    }
}