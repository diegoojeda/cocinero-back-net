using System.Collections.Generic;
using System.Linq;
using ElCocineroBack.Domain.RecipeIngredient;

namespace ElCocineroBack.Infrastructure
{
    public class EfRecipeIngredientRepository : BaseRepository, IRecipeIngredientRepository
    {
        public EfRecipeIngredientRepository(AppDbContext context) : base(context)
        {
        }

        public void SaveAll(IEnumerable<RecipeIngredient> recipeIngredients)
        {
            _context
                .RecipeIngredients
                .AddRange(recipeIngredients.Select(x => x));
        }
    }
}