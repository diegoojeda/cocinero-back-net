using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElCocineroBack.Controllers;

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

        public Task<Recipe> SaveAsync(Recipe recipe)
        {
            return _recipeRepository.SaveAsync(recipe);
        }
    }
}