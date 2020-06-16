using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ElCocineroBack.Controllers.Author.Request;
using ElCocineroBack.Controllers.Author.Response;
using ElCocineroBack.Domain.ValueObjects;

namespace ElCocineroBack.Domain.Author
{
    public class Author
    {
        public string AuthorId { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<Recipe.Recipe> Recipes { get; set; }

        public Author(string authorId, string name)
        {
            AuthorId = authorId;
            Name = name;
        }

        public static implicit operator string(Author author)
        {
            return author.AuthorId;
        }

        public static implicit operator AuthorResponseDto(Author author)
        {
            return new AuthorResponseDto(author.AuthorId, author.Name);
        }

        public static implicit operator Author(CreateAuthorRequestDto author)
        {
            return new Author(new AuthorId(), new NonNullString(author.Name))
            {
                Recipes = new List<Recipe.Recipe>()
            };
        }
    }
}