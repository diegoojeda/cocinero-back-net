using System.Collections.Generic;
using System.Threading.Tasks;
using ElCocineroBack.Controllers;
using ElCocineroBack.Domain.Author;

namespace ElCocineroBack.Domain.Recipe
{
    public class RecipeApplicationService
    {
        private readonly AuthorService _authorService;
        private readonly RecipeService _recipeService;

        public RecipeApplicationService(AuthorService authorService, RecipeService recipeService)
        {
            _authorService = authorService;
            _recipeService = recipeService;
        }


        public Task<IEnumerable<Recipe>> getAllRecipes()
        {
            return _recipeService.getAllRecipes();
        }

        public async Task<Recipe> SaveAsync(SaveRecipeRequestDto body)
        {
            var author = await _authorService.FindAsync(body.AuthorId);
            return await _recipeService.SaveAsync(new Recipe(body.Name, body.Description, author));
        }
    }
}