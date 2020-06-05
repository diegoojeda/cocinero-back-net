using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElCocineroBack.Domain.Recipe;
using Microsoft.AspNetCore.Mvc;

namespace ElCocineroBack.Controllers
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
            return (await _recipeService.GetAllRecipes()).Select<Recipe, RecipeResponseDto>(x => x);
        }

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<RecipeResponseDto>), 200)]
        public async Task<RecipeResponseDto> SaveRecipe([FromBody] SaveRecipeRequestDto body)
        {
            return await _recipeService.SaveAsync(body);
        }
    }

    public class RecipeResponseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AuthorId { get; set; }

        public RecipeResponseDto(string id, string name, string description, string authorId)
        {
            Id = id;
            Name = name;
            Description = description;
            AuthorId = authorId;
        }
    }

    public class SaveRecipeRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string AuthorId { get; set; }
    }
}