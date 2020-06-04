using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ElCocineroBack.Domain.Recipe;

namespace ElCocineroBack.Domain.Author
{
    public class AuthorState
    {
        [Key] public string AuthorKey { get; set; }

        public string Name { get; set; }

        public List<RecipeState> Recipes { get; set; }

        public Author ToAuthor()
        {
            return new Author(this);
        }

        public Author ToAuthor(AuthorState state)
        {
            return new Author(state);
        }
    }
}