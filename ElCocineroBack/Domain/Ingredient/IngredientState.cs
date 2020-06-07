using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ElCocineroBack.Domain.Recipe.RecipeIngredient;

namespace ElCocineroBack.Domain.Ingredient
{
    public class IngredientState
    {
        [Key] public string IngredientKey { get; set; }
        public string Name { get; set; }
        public IEnumerable<RecipeIngredientState> Recipes { get; set; }

        public Ingredient ToIngredient()
        {
            return new Ingredient(this);
        }

        public Ingredient ToIngredient(IngredientState state)
        {
            return new Ingredient(state);
        }
    }
}