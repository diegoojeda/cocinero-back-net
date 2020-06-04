using System;
using ElCocineroBack.Controllers;
using ElCocineroBack.Domain.ValueObjects;

namespace ElCocineroBack.Domain.Recipe
{
    public class Recipe
    {
        private RecipeId Id;
        private NonNullString Name;
        private NonNullString Description;
        private Author.Author Author;

        private RecipeState State;

        public Recipe(RecipeId id, NonNullString name, NonNullString description, Author.Author author)
        {
            Id = id;
            Name = name;
            Description = description;
            Author = author;
        }

        internal Recipe(RecipeState state)
        {
            State = state;
        }

        public static implicit operator RecipeResponseDto(Recipe recipe)
        {
            return new RecipeResponseDto(recipe.Id.ToString(), recipe.Name, recipe.Description, recipe.Author);
        }
    }
}