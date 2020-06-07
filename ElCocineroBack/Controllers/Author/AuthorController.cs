using System.Collections.Generic;
using System.Threading.Tasks;
using ElCocineroBack.Controllers.Author.Request;
using ElCocineroBack.Controllers.Author.Response;
using ElCocineroBack.Controllers.Recipe.Response;
using ElCocineroBack.Domain.Author;
using ElCocineroBack.Domain.Author.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ElCocineroBack.Controllers.Author
{
    [Route("/api/author")]
    [Produces("application/json")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly AuthorApplicationService _authorService;

        public AuthorController(AuthorApplicationService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AuthorResponseDto), 200)]
        public async Task<AuthorResponseDto> SaveAsync([FromBody] CreateAuthorRequestDto body)
        {
            return await _authorService.SaveAsync(body);
        }

        [HttpGet("{authorId}/recipes")]
        [ProducesResponseType(typeof(List<RecipeResponseDto>), 200)]
        public async Task<IActionResult> FindAllRecipesForAuthor(string authorId)
        {
            try
            {
                return Ok(await _authorService.FindAllRecipes(authorId));
            }
            catch (AuthorNotFoundException anfe)
            {
                return NotFound(anfe.Message);
            }
        }
    }
}