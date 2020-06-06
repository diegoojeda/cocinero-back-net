using System.ComponentModel.DataAnnotations;

namespace ElCocineroBack.Domain.Ingredient
{
    public class IngredientState
    {
        [Key] public string IngredientKey { get; set; }
        public string Name { get; set; }

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