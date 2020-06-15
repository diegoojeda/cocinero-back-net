using System.Collections.Generic;
using System.Linq;
using ElCocineroBack.Controllers.Recipe.Request;
using ElCocineroBack.Domain.Author;
using ElCocineroBack.Domain.Author.Exceptions;
using ElCocineroBack.Domain.Ingredient;
using ElCocineroBack.Domain.Ingredient.Exceptions;

namespace ElCocineroBack.Domain.Recipe
{
    public class RecipeApplicationService
    {
        private readonly AuthorService _authorService;
        private readonly RecipeService _recipeService;
        private readonly IngredientService _ingredientService;
        public IngredientService IngredientsService { get; }

        public RecipeApplicationService(AuthorService authorService, RecipeService recipeService,
            IngredientService ingredientService)
        {
            _authorService = authorService;
            _recipeService = recipeService;
            _ingredientService = ingredientService;
            IngredientsService = ingredientService;
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

            var fullIngredients = _ingredientService.FindAllByIds(body.Ingredients.Select(x => x.Id));

            var insertedRecipe = _recipeService.Save(
                Recipe.Create(
                    body.Name,
                    body.Description,
                    author,
                    body.Ingredients,
                    fullIngredients)
            );
            return insertedRecipe;
        }
    }
}