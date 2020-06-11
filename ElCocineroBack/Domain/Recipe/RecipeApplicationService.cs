using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElCocineroBack.Controllers.Recipe.Request;
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

        public Task<IEnumerable<Recipe>> GetAllRecipes()
        {
            return _recipeService.FindAllAsync();
        }

        public async Task<Recipe> SaveAsync(CreateRecipeRequestDto body)
        {
            var author = await _authorService.FindAsync(body.AuthorId);
            var newRecipeId = new RecipeId();
            var ingredients = body.Ingredients.Select(x =>
                new RecipeIngredient.RecipeIngredient(newRecipeId, x.Id ?? Guid.NewGuid().ToString(), x.Amount, x.Unit));
            return await _recipeService.SaveAsync(new Recipe(newRecipeId, body.Name, body.Description, author, ingredients));
        }
    }
}