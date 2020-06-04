using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ElCocineroBack.Domain.Recipe;

namespace ElCocineroBack.Domain.Author
{
    public class AuthorState
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("AuthorStateFk")]
        public List<RecipeState> Recipes { get; set; }

        public Author ToAuthor()
        {
            return new Author(this);
        }

        public static Author ToAuthor(AuthorState state)
        {
            return new Author(state);
        }
    }
}