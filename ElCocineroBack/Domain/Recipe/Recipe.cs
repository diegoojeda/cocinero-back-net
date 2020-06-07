using System.Collections.Generic;
using System.Linq;
using ElCocineroBack.Controllers.Recipe.Response;
using ElCocineroBack.Domain.ValueObjects;

namespace ElCocineroBack.Domain.Recipe
{
    using RecipeName = NonNullString;
    using RecipeDescription = NonNullString;

    public class Recipe
    {
        public RecipeId Id => new RecipeId(State.RecipeKey);
        private RecipeName Name => new NonNullString(State.Name);
        private RecipeDescription Description => new NonNullString(State.Description);
        private Author.Author Author => State.Author.ToAuthor();

        // private IEnumerable<RecipeIngredient.RecipeIngredient> Ingredients =>
        //     State.Ingredients.Select(x => x.ToRecipeIngredient());

        public RecipeState State { get; }

        public Recipe(
            RecipeId id,
            NonNullString name,
            NonNullString description,
            Author.Author author,
            IEnumerable<RecipeIngredient.RecipeIngredient> ingredients)
        {
            State = new RecipeState
            {
                RecipeKey = id.Id,
                Name = name,
                Description = description,
                Author = author.State,
                AuthorId = author.Id,
                Ingredients = ingredients.Select(x => x.State)
            };
        }

        internal Recipe(RecipeState state)
        {
            State = state;
        }

        public static implicit operator RecipeResponseDto(Recipe recipe)
        {
            return new RecipeResponseDto(
                recipe.Id,
                recipe.Name,
                recipe.Description,
                recipe.Author.Id.Id
                // recipe.Ingredients
                );
        }
    }
}