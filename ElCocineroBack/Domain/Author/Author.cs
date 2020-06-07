using System.Collections.Generic;
using System.Linq;
using ElCocineroBack.Controllers.Author.Request;
using ElCocineroBack.Controllers.Author.Response;
using ElCocineroBack.Domain.Recipe;
using ElCocineroBack.Domain.ValueObjects;

namespace ElCocineroBack.Domain.Author
{
    using AuthorName = NonNullString;

    public class Author
    {
        public AuthorId Id => new AuthorId(State.AuthorKey);

        private AuthorName Name => new NonNullString(State.Name);

        private IEnumerable<Recipe.Recipe> Recipes => State.Recipes.Select(x => new Recipe.Recipe(x));

        public AuthorState State { get; }

        public Author(AuthorId id, NonNullString name)
        {
            State = new AuthorState {AuthorKey = id.Id, Name = name, Recipes = new List<RecipeState>()};
        }

        internal Author(AuthorState state)
        {
            State = state;
        }

        public static implicit operator string(Author author)
        {
            return author.Id.ToString();
        }

        public static implicit operator AuthorResponseDto(Author author)
        {
            return new AuthorResponseDto(author.Id.Id, author.Name);
        }

        public static implicit operator Author(CreateAuthorRequestDto author)
        {
            return new Author(new AuthorId(), new NonNullString(author.Name));
        }
    }
}