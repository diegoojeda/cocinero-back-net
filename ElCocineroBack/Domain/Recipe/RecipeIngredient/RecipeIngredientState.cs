using System.ComponentModel.DataAnnotations.Schema;
using ElCocineroBack.Domain.Ingredient;

namespace ElCocineroBack.Domain.Recipe.RecipeIngredient
{
    public class RecipeIngredientState
    {
        public string RecipeId { get; set; }
        public RecipeState Recipe;
        public string IngredientId { get; set; }
        public IngredientState Ingredient;
        
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