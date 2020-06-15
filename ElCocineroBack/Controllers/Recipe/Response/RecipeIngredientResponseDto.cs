using System.Collections;
using ElCocineroBack.Controllers.Ingredient.Response;

namespace ElCocineroBack.Controllers.Recipe.Response
{
    public class RecipeIngredientResponseDto
    {
        public string IngredientId { get; set; }
        public string IngredientKey { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
    }
}