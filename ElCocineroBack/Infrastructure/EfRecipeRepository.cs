using System.Collections.Generic;
using System.Linq;
using ElCocineroBack.Domain.Recipe;
using Microsoft.EntityFrameworkCore;

namespace ElCocineroBack.Infrastructure
{
    public class EfRecipeRepository : BaseRepository, IRecipeRepository
    {
        public EfRecipeRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Recipe> FindAll()
        {
            return _context
                .Recipes;
        }

        public Recipe Save(Recipe recipe)
        {
            return _context.Recipes.Add(recipe).Entity;
        }
        
        public IEnumerable<Recipe> FindAllForAuthor(string authorId)
        {
            return _context
                .Recipes
                .Where(x => x.AuthorId == authorId);
        }

        public Recipe FindById(RecipeId recipeId)
        {
            return _context
                .Recipes
                .FirstOrDefault(x => x.RecipeId == recipeId);
        }
    }
}