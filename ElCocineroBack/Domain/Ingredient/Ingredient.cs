using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ElCocineroBack.Controllers.Ingredient.Request;
using ElCocineroBack.Controllers.Ingredient.Response;
using ElCocineroBack.Domain.RecipeIngredient;

namespace ElCocineroBack.Domain.Ingredient
{
    public class Ingredient
    {
        [Key] public string Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public virtual IEnumerable<RecipeIngredient.RecipeIngredient> Recipes { get; set; }

        public Ingredient(string id, string name, string key)
        {
            Id = id;
            Name = name;
            Key = key;
        }

        public static implicit operator IngredientResponseDto(Ingredient ingredient)
        {
            return new IngredientResponseDto
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Key = ingredient.Key
            };
        }

        public static implicit operator Ingredient(CreateIngredientRequestDto ingredient)
        {
            return new Ingredient(new IngredientId(), ingredient.Name, ingredient.Key);
        }
    }
}