using System.Threading.Tasks;
using ElCocineroBack.Domain.Author;
using Microsoft.AspNetCore.Mvc;

namespace ElCocineroBack.Controllers
{
    [Route("/api/author")]
    [Produces("application/json")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly AuthorService _authorService;

        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AuthorResponseDto), 200)]
        public async Task<AuthorResponseDto> SaveAsync([FromBody] CreateAuthorRequestDto body)
        {
            return await _authorService.SaveAsync(body);
        }
    }

    public class AuthorResponseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public AuthorResponseDto(string authorId, string authorName)
        {
            Id = authorId;
            Name = authorName;
        }
    }

    public class CreateAuthorRequestDto
    {
        public string Name { get; set; }
    }
}