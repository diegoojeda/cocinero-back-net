using System;
using System.Collections.Generic;
using ElCocineroBack.Domain.Ingredient;
using ElCocineroBack.Domain.Recipe.RecipeIngredient;

namespace ElCocineroBack.Infrastructure.Seed
{
    public static class IngredientsSeeding
    {
        public static IEnumerable<IngredientState> GetAllIngredients()
        {
            return new List<IngredientState>
            {
                new IngredientState
                {
                    IngredientKey = Guid.NewGuid().ToString(),
                    Name = "Harina",
                    Recipes = new List<RecipeIngredientState>()
                },
                new IngredientState
                {
                    IngredientKey = Guid.NewGuid().ToString(),
                    Name = "Pollo",
                    Recipes = new List<RecipeIngredientState>()
                },
                new IngredientState
                {
                    IngredientKey = Guid.NewGuid().ToString(),
                    Name = "Manzanas",
                    Recipes = new List<RecipeIngredientState>()
                },
                new IngredientState
                {
                    IngredientKey = Guid.NewGuid().ToString(),
                    Name = "Platanos",
                    Recipes = new List<RecipeIngredientState>()
                }
            };
        }
    }
}