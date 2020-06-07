using System.ComponentModel.DataAnnotations.Schema;

namespace ElCocineroBack.Domain.Recipe.RecipeIngredient
{
    public class RecipeIngredientState
    {
        public string RecipeId { get; set; }
        public string IngredientId { get; set; }
        
        public Recipe Recipe;
        public Ingredient.Ingredient Ingredient;
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