using ElCocineroBack.Controllers;
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

        public RecipeState State { get; }

        public Recipe(RecipeId id, NonNullString name, NonNullString description, Author.Author author)
        {
            State = new RecipeState
            {
                RecipeKey = id.Id,
                Name = name,
                Description = description,
                Author = author.State,
                AuthorId = author.Id
            };
        }

        internal Recipe(RecipeState state)
        {
            State = state;
        }

        public Recipe(NonNullString name, NonNullString description, Author.Author author) :
            this(new RecipeId(), name, description, author)
        {
        }

        public static implicit operator RecipeResponseDto(Recipe recipe)
        {
            return new RecipeResponseDto(recipe.Id, recipe.Name, recipe.Description, recipe.Author.Id.Id);
        }
    }
}