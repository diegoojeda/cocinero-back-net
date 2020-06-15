using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ElCocineroBack.Controllers.Recipe.Request;
using ElCocineroBack.Controllers.Recipe.Response;

namespace ElCocineroBack.Domain.Recipe
{
    public class Recipe
    {
        [Key] public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AuthorId { get; set; }
        public virtual Author.Author Author { get; set; }
        public virtual IEnumerable<RecipeIngredient.RecipeIngredient> Ingredients { get; set; }

        public Recipe()
        {
            Ingredients = new List<RecipeIngredient.RecipeIngredient>();
        }

        public Recipe(string id, string name, string description, string authorId,
            IEnumerable<RecipeIngredient.RecipeIngredient> ingredients)
        {
            Id = id;
            Name = name;
            Description = description;
            AuthorId = authorId;
            Ingredients = ingredients;
        }

        public static implicit operator RecipeResponseDto(Recipe recipe)
        {
            return new RecipeResponseDto(
                recipe.Id,
                recipe.Name,
                recipe.Description,
                recipe.Author.Id,
                recipe.Ingredients
            );
        }

        public static Recipe Create(string name, string description, Author.Author author,
            IEnumerable<RecipeIngredientDto> ingredients, IEnumerable<Ingredient.Ingredient> fullIngredients)
        {
            var recipeId = Guid.NewGuid().ToString();

            var recipeIngredients = fullIngredients
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

            return new Recipe(recipeId, name, description, author, recipeIngredients);
        }
    }
}