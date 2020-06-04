using System.Collections.Generic;
using ElCocineroBack.Controllers;
using ElCocineroBack.Domain.Recipe;
using ElCocineroBack.Domain.ValueObjects;

namespace ElCocineroBack.Domain.Author
{
    public class Author
    {
        private AuthorId Id;
        private NonNullString Name;

        public AuthorState State;

        public Author(AuthorId id, NonNullString name)
        {
            Id = id;
            Name = name;
            State = new AuthorState {Id = id.Id, Name = name, Recipes = new List<RecipeState>()};
        }

        internal Author(AuthorState state)
        {
            Id = new AuthorId(state.Id);
            Name = new NonNullString(state.Name);
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