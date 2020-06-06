using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElCocineroBack.Domain.Ingredient;
using Microsoft.EntityFrameworkCore;

namespace ElCocineroBack.Infrastructure
{
    public class EfIngredientRepository : BaseRepository, IIngredientRepository
    {
        public EfIngredientRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Ingredient>> FindAllAsync()
        {
            return await _context
                .Ingredients
                .Select(x => x.ToIngredient())
                .ToListAsync();
        }

        public async Task<Ingredient> SaveAsync(Ingredient ingredient)
        {
            return (await _context.Ingredients.AddAsync(ingredient.State)).Entity.ToIngredient();
        }
    }
}