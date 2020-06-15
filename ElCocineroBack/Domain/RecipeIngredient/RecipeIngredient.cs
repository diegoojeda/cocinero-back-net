using ElCocineroBack.Controllers.Recipe.Response;

namespace ElCocineroBack.Domain.RecipeIngredient
{
    public class RecipeIngredient
    {
        public string RecipeId { get; set; }
        public string IngredientId { get; set; }
        public virtual Ingredient.Ingredient Ingredient { get; set; }
        public virtual Recipe.Recipe Recipe { get; set; }

        public int Amount { get; set; }
        public string Unit { get; set; }

        public RecipeIngredient(string recipeId, string ingredientId, int amount, string unit)
        {
            RecipeId = recipeId;
            IngredientId = ingredientId;
            Amount = amount;
            Unit = unit;
        }

        public static implicit operator RecipeIngredientResponseDto(RecipeIngredient recipeIngredient)
        {
            return new RecipeIngredientResponseDto
            {
                IngredientId = recipeIngredient.IngredientId,
                IngredientKey = recipeIngredient.Ingredient.Key,
                Amount = recipeIngredient.Amount,
                Unit = recipeIngredient.Unit
            };
        }
    }
}