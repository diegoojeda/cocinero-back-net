namespace ElCocineroBack.Controllers.Recipe.Request
{
    public class RecipeStepRequestDto
    {
        public int Position { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}