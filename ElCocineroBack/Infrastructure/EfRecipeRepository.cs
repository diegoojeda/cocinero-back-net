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
            return await _context.Recipes.Select(x => x.ToRecipe()).ToListAsync();
        }

        public async Task<Recipe> SaveAsync(Recipe recipe)
        {
            var inserted = await _context.Recipes.AddAsync(recipe.State);
            return inserted.Entity.ToRecipe();
        }
    }
}