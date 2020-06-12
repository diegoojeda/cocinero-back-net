using ElCocineroBack.Domain.Ingredient;
using ElCocineroBack.Domain.Recipe;

namespace ElCocineroBack.Domain.RecipeIngredient
{
    public class RecipeIngredientState
    {
        public string RecipeId { get; set; }
        public RecipeState Recipe { get; set; }

        public string IngredientId { get; set; }
        public IngredientState Ingredient { get; set; }

        public int Amount { get; set; }
        public string Unit { get; set; }

        public RecipeIngredient ToRecipeIngredient()
        {
            return new RecipeIngredient(this);
        }

        public RecipeIngredient ToRecipeIngredient(RecipeIngredientState state)
        {
            return new RecipeIngredient(state);
        }
    }
}