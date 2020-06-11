using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ElCocineroBack.Controllers.Ingredient.Response;
using ElCocineroBack.Controllers.Recipe.Request;
using ElCocineroBack.Domain.Recipe.RecipeIngredient;

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
            Ingredients = ingredients.Select<RecipeIngredient, RecipeIngredientResponseDto>(x => x);
        }
    }
}