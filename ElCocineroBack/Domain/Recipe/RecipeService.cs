using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElCocineroBack.Domain.Recipe
{
    public class RecipeService
    {

        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public Task<IEnumerable<Recipe>> getAllRecipes()
        {
            return _recipeRepository.FindAllAsync();
        }
    }
}