using System.Collections.Generic;

namespace ElCocineroBack.Domain.Recipe
{
    public interface IRecipeRepository
    {
        IEnumerable<Recipe> FindAll();
        Recipe Save(Recipe recipe);
        IEnumerable<Recipe> FindAllForAuthor(string authorId);
        Recipe FindById(RecipeId recipeId);
    }
}