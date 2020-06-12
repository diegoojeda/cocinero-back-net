using System.Collections.Generic;

namespace ElCocineroBack.Domain.RecipeIngredient
{
    public interface IRecipeIngredientRepository
    {
        public void SaveAll(IEnumerable<RecipeIngredient> recipeIngredients);
    }
}