using System.Collections.Generic;

namespace ElCocineroBack.Controllers.Recipe.Request
{
    public class CreateRecipeRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string AuthorId { get; set; }
        // public IEnumerable<RecipeIngredientDto> Ingredients { get; set; }
    }
}