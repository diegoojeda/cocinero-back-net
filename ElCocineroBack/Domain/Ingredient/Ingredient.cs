using System.Collections.Generic;
using ElCocineroBack.Controllers.Ingredient.Request;
using ElCocineroBack.Controllers.Ingredient.Response;

namespace ElCocineroBack.Domain.Ingredient
{
    public class Ingredient
    {
        public string IngredientId { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public virtual IEnumerable<RecipeIngredient.RecipeIngredient> Recipes { get; set; }

        public Ingredient(
            string ingredientId,
            string name,
            string key)
        {
            IngredientId = ingredientId;
            Name = name;
            Key = key;
        }

        public static implicit operator IngredientResponseDto(Ingredient ingredient)
        {
            return new IngredientResponseDto
            {
                Id = ingredient.IngredientId,
                Name = ingredient.Name,
                Key = ingredient.Key
            };
        }

        public static implicit operator Ingredient(CreateIngredientRequestDto ingredient)
        {
            return new Ingredient(new IngredientId(), ingredient.Name, ingredient.Key)
            {
                Recipes = new List<RecipeIngredient.RecipeIngredient>()
            };
        }
    }
}