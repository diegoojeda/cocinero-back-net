using System;
using System.Collections.Generic;
using System.Linq;
using ElCocineroBack.Controllers.Recipe.Request;
using ElCocineroBack.Controllers.Recipe.Response;

namespace ElCocineroBack.Domain.Recipe
{
    public class Recipe
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AuthorId { get; set; }
        public virtual Author.Author Author { get; set; }
        public virtual IEnumerable<RecipeIngredient.RecipeIngredient> Ingredients { get; set; }
        public virtual IEnumerable<RecipeStep.RecipeStep> Steps { get; set; }

        public Recipe(string id,
            string name,
            string description,
            string authorId)
        {
            Id = id;
            Name = name;
            Description = description;
            AuthorId = authorId;
        }

        public static implicit operator RecipeResponseDto(Recipe recipe)
        {
            return new RecipeResponseDto(
                recipe.Id,
                recipe.Name,
                recipe.Description,
                recipe.AuthorId,
                recipe.Ingredients,
                recipe.Steps
            );
        }

        public static Recipe Create(string name,
            string description,
            Author.Author author,
            IEnumerable<RecipeIngredientDto> ingredients,
            IEnumerable<Ingredient.Ingredient> fullIngredients,
            IEnumerable<RecipeStepRequestDto> steps)
        {
            var recipeId = Guid.NewGuid().ToString();

            var recipeIngredients = MatchWithDbIngredients(ingredients, fullIngredients, recipeId);
            var recipeSteps = steps
                .Select(x =>
                    new RecipeStep.RecipeStep(
                        recipeId,
                        x.Position,
                        x.ImageUrl,
                        x.Description)
                ).ToList();

            var newRecipe = new Recipe(recipeId, name, description, author)
            {
                Ingredients = recipeIngredients, 
                Steps = recipeSteps
            };
            return newRecipe;
        }

        private static List<RecipeIngredient.RecipeIngredient> MatchWithDbIngredients(
            IEnumerable<RecipeIngredientDto> ingredients,
            IEnumerable<Ingredient.Ingredient> fullIngredients,
            string recipeId)
        {
            return fullIngredients
                .SelectMany(x =>
                    ingredients
                        .Where(y => y.Id == x.Id)
                        .Select(y =>
                            new RecipeIngredient.RecipeIngredient(
                                recipeId,
                                x.Id,
                                y.Amount,
                                y.Unit
                            ))
                ).ToList();
        }
    }
}