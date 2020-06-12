using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElCocineroBack.Domain.Recipe
{
    public interface IRecipeRepository
    {
        IEnumerable<Recipe> FindAll();
        Recipe Save(Recipe recipe);
        IEnumerable<Recipe> FindAllForAuthor(string authorId);
        IEnumerable<RecipeIngredient.RecipeIngredient> SaveIngredients(IEnumerable<RecipeIngredient.RecipeIngredient> ingredients);
    }
}