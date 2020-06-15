using System.Collections.Generic;
using System.Linq;
using ElCocineroBack.Domain.RecipeIngredient;

namespace ElCocineroBack.Controllers.Recipe.Response
{
    public class RecipeResponseDto
    {
        public string Id { get; }
        public string Name { get; }
        public string Description { get; }
        public string AuthorId { get; }
        public IEnumerable<RecipeIngredientResponseDto> Ingredients { get; }

        public RecipeResponseDto(string id, 
            string name,
            string description, 
            string authorId,
            IEnumerable<RecipeIngredient> ingredients
            )
        {
            Id = id;
            Name = name;
            Description = description;
            AuthorId = authorId;
            Ingredients = ingredients.ToList().Select<RecipeIngredient, RecipeIngredientResponseDto>(x => x);
        }
    }
}