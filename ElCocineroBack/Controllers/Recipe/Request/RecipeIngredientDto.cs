using System.Text.Json.Serialization;

namespace ElCocineroBack.Controllers.Recipe.Request
{
    public class RecipeIngredientDto
    {
        public string Id { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
    }
}