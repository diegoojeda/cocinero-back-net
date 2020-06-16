using ElCocineroBack.Controllers.Recipe.Response;

namespace ElCocineroBack.Domain.RecipeStep
{
    public class RecipeStep
    {
        public string RecipeId { get; set; }
        public int Position { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }

        public RecipeStep(string recipeId, int position, string imageUrl, string description)
        {
            RecipeId = recipeId;
            Position = position;
            ImageUrl = imageUrl;
            Description = description;
        }

        public static implicit operator RecipeStepResponseDto(RecipeStep step)
        {
            return new RecipeStepResponseDto
            {
                Description = step.Description,
                ImageUrl = step.ImageUrl,
                Position = step.Position
            };
        }
    }
}