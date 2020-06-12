using System.Collections.Generic;
using System.Linq;
using ElCocineroBack.Controllers.Recipe.Request;
using ElCocineroBack.Controllers.Recipe.Response;
using ElCocineroBack.Domain.Recipe;
using Microsoft.AspNetCore.Mvc;

namespace ElCocineroBack.Controllers.Recipe
{
    [Route("/api/recipe")]
    [Produces("application/json")]
    [ApiController]
    public class RecipeController : Controller
    {
        private readonly RecipeApplicationService _recipeService;

        public RecipeController(RecipeApplicationService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RecipeResponseDto>), 200)]
        public IEnumerable<RecipeResponseDto> GetAllRecipes()
        {
            return _recipeService.GetAllRecipes().Select<Domain.Recipe.Recipe, RecipeResponseDto>(x => x);
        }

        [HttpPost]
        [ProducesResponseType(typeof(RecipeResponseDto), 200)]
        public RecipeResponseDto CreateRecipe([FromBody] CreateRecipeRequestDto body)
        {
            return _recipeService.Save(body);
        }
    }
}