using System.ComponentModel.DataAnnotations;
using ElCocineroBack.Domain.Author;

namespace ElCocineroBack.Domain.Recipe
{
    public class RecipeState
    {
        [Key]
        public string Id {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}

        public string AuthorId { get; set; }
        public AuthorState Author { get; set; }
        public Recipe ToRecipe()
        {
            return new Recipe(this);
        }

        public static Recipe ToRecipe(RecipeState state)
        {
            return new Recipe(state);
        }
    }
    
}