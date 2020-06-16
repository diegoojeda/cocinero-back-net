using System.Collections.Generic;
using System.Linq;
using ElCocineroBack.Domain.RecipeIngredient;
using ElCocineroBack.Domain.RecipeStep;

namespace ElCocineroBack.Controllers.Recipe.Response
{
    public class RecipeResponseDto
    {
        public string Id { get; }
        public string Name { get; }
        public string Description { get; }
        public string AuthorId { get; }
        public IEnumerable<RecipeIngredientResponseDto> Ingredients { get; }
        public IEnumerable<RecipeStepResponseDto> Steps { get; }

        public RecipeResponseDto(string id,
            string name,
            string description,
            string authorId,
            IEnumerable<RecipeIngredient> ingredients,
            IEnumerable<RecipeStep> steps
        )
        {
            Id = id;
            Name = name;
            Description = description;
            AuthorId = authorId;
            Ingredients = ingredients.ToList().Select<RecipeIngredient, RecipeIngredientResponseDto>(x => x);
            Steps = steps.ToList().Select<RecipeStep, RecipeStepResponseDto>(x => x);
        }
    }
}