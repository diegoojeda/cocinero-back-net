using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElCocineroBack.Controllers;
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

        public async Task<Author> FindAsync(AuthorId authorId)
        {
            return await _authorService.FindAsync(authorId);
        }

        public async Task<Author> SaveAsync(Author author)
        {
            return await _authorService.SaveAsync(author);
        }


        public async Task<IEnumerable<RecipeResponseDto>> FindAllRecipes(string authorId)
        {
            return (await _recipeService.FindAllForAuthorAsync(authorId))
                .Select<Recipe.Recipe, RecipeResponseDto>(x => x);
        }
    }
}