using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElCocineroBack.Domain.Recipe;
using Microsoft.EntityFrameworkCore;

namespace ElCocineroBack.Infrastructure
{
    public class EfRecipeRepository : BaseRepository, IRecipeRepository
    {
        public EfRecipeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Recipe>> FindAllAsync()
        {
            return await _context
                .Recipes
                .Include(x => x.Author)
                .Select(x => x.ToRecipe())
                .ToListAsync();
        }

        public async Task<Recipe> SaveAsync(Recipe recipe)
        {
            return (await _context.Recipes.AddAsync(recipe.State)).Entity.ToRecipe();
        }

        public async Task<IEnumerable<Recipe>> FindAllForAuthorAsync(string authorId)
        {
            return await _context
                .Recipes
                .Where(x => x.AuthorId == authorId)
                .Include(x => x.Author)
                .Select(x => x.ToRecipe())
                .ToListAsync();
        }
    }
}