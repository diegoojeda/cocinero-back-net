using System.Collections.Generic;
using System.Linq;
using ElCocineroBack.Controllers.Recipe.Request;
using ElCocineroBack.Domain.Author;
using ElCocineroBack.Domain.Author.Exceptions;
using ElCocineroBack.Domain.Ingredient.Exceptions;
using ElCocineroBack.Domain.RecipeIngredient;

namespace ElCocineroBack.Domain.Recipe
{
    public class RecipeApplicationService
    {
        private readonly AuthorService _authorService;
        private readonly RecipeService _recipeService;
        private readonly RecipeIngredientService _recipeIngredientService;

        public RecipeApplicationService(AuthorService authorService, RecipeService recipeService,
            RecipeIngredientService recipeIngredientService)
        {
            _authorService = authorService;
            _recipeService = recipeService;
            _recipeIngredientService = recipeIngredientService;
        }

        public IEnumerable<Recipe> GetAllRecipes()
        {
            return _recipeService.FindAll();
        }

        public Recipe Save(CreateRecipeRequestDto body)
        {
            var author = _authorService.Find(body.AuthorId);
            if (author == null)
            {
                throw new AuthorNotFoundException(body.AuthorId);
            }

            if (body.Ingredients.Any(x => x.Id == null))
            {
                throw new InvalidIngredientsException();
            }

            // body.Ingredients.Select(x => ingredientsService.getById)
            
            var insertedRecipe = _recipeService.Save(
                Recipe.Create(
                    body.Name,
                    body.Description,
                    author,
                    body.Ingredients)
            );
            return insertedRecipe;
        }
    }
}