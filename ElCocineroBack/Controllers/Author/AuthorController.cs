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
        public AuthorResponseDto SaveAsync([FromBody] CreateAuthorRequestDto body)
        {
            return _authorService.Save(body);
        }

        [HttpGet("{authorId}/recipes")]
        [ProducesResponseType(typeof(IEnumerable<RecipeResponseDto>), 200)]
        public IActionResult FindAllRecipesForAuthor(string authorId)
        {
            try
            {
                return Ok(_authorService.FindAllRecipes(authorId));
            }
            catch (AuthorNotFoundException anfe)
            {
                return NotFound(anfe.Message);
            }
        }
    }
}