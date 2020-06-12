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

            var recipeId = new RecipeId();

            var ingredients = body.Ingredients.Select(x =>
                new RecipeIngredient.RecipeIngredient(
                    recipeId,
                    x.Id,
                    x.Amount,
                    x.Unit
                )
            );

            var recipeIngredients = ingredients.ToList();

            // _recipeIngredientService.SaveAll(recipeIngredients);

            var insertedRecipe = _recipeService.Save(
                new Recipe(
                    recipeId,
                    body.Name,
                    body.Description,
                    author,
                    recipeIngredients
                )
            );

            return insertedRecipe;
        }
    }
}