using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<RecipeResponseDto>> GetAllRecipesAsync()
        {
            return (await _recipeService.GetAllRecipes()).Select<Domain.Recipe.Recipe, RecipeResponseDto>(x => x);
        }

        [HttpPost]
        [ProducesResponseType(typeof(RecipeResponseDto), 200)]
        public async Task<RecipeResponseDto> CreateRecipeAsync([FromBody] CreateRecipeRequestDto body)
        {
            return await _recipeService.SaveAsync(body);
        }
    }
}