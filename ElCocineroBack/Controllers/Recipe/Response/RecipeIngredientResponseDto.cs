using System.Collections;

namespace ElCocineroBack.Controllers.Recipe.Response
{
    public class RecipeIngredientResponseDto
    {
        public string IngredientId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
    }
}