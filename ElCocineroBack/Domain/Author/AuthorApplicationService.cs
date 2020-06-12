using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElCocineroBack.Controllers.Recipe.Response;
using ElCocineroBack.Domain.Author.Exceptions;
using ElCocineroBack.Domain.Recipe;

namespace ElCocineroBack.Domain.Author
{
    public class AuthorApplicationService
    {
        private readonly AuthorService _authorService;
        private readonly RecipeService _recipeService;

        public AuthorApplicationService(AuthorService authorService, RecipeService recipeService)
        {
            _authorService = authorService;
            _recipeService = recipeService;
        }

        public Author Find(AuthorId authorId)
        {
            return _authorService.Find(authorId);
        }

        public Author Save(Author author)
        {
            return _authorService.SaveAsync(author);
        }

        public IEnumerable<RecipeResponseDto> FindAllRecipes(string authorId)
        {
            if (! _authorService.Any(authorId))
            {
                throw new AuthorNotFoundException(authorId);
            }
            return _recipeService.FindAllForAuthor(authorId)
                .Select<Recipe.Recipe, RecipeResponseDto>(x => x);
        }
    }
}