using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ElCocineroBack.Controllers.Author.Request;
using ElCocineroBack.Controllers.Author.Response;
using ElCocineroBack.Domain.ValueObjects;

namespace ElCocineroBack.Domain.Author
{
    public class Author
    {
        [Key] public string Id { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<Recipe.Recipe> Recipes { get; set; }

        public Author(string id, string name)
        {
            Id = id;
            Name = name;
            Recipes = new List<Recipe.Recipe>();
        }

        public static implicit operator string(Author author)
        {
            return author.Id;
        }

        public static implicit operator AuthorResponseDto(Author author)
        {
            return new AuthorResponseDto(author.Id, author.Name);
        }

        public static implicit operator Author(CreateAuthorRequestDto author)
        {
            return new Author(new AuthorId(), new NonNullString(author.Name));
        }
        
    }
}