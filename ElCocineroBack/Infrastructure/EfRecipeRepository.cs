using System.Collections.Generic;
using System.Linq;
using ElCocineroBack.Domain.Recipe;
using ElCocineroBack.Domain.Recipe.RecipeIngredient;
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
                .Recipes
                .Include(x => x.Author)
                .Include(x => x.Ingredients)
                .Select(x => x.ToRecipe());
        }

        public Recipe Save(Recipe recipe)
        {
            var saved = _context.Recipes.Add(recipe.State);
            return saved.Entity.ToRecipe();
        }

        public IEnumerable<Recipe> FindAllForAuthor(string authorId)
        {
            return _context
                .Recipes
                .Where(x => x.AuthorId == authorId)
                .Include(x => x.Author)
                .Include(x => x.Ingredients)
                .Select(x => x.ToRecipe());
        }
        
        public IEnumerable<RecipeIngredient> SaveIngredients(IEnumerable<RecipeIngredient> ingredients)
        {
            _context
                .RecipeIngredients
                .AddRangeAsync(ingredients.Select(x => x.State));
            return new List<RecipeIngredient>();//TODO
            
        }
    }
}