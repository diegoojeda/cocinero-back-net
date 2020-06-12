using System.Collections.Generic;
using System.Linq;
using ElCocineroBack.Domain.Ingredient;
using Microsoft.EntityFrameworkCore;

namespace ElCocineroBack.Infrastructure
{
    public class EfIngredientRepository : BaseRepository, IIngredientRepository
    {
        public EfIngredientRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Ingredient> FindAll()
        {
            return _context
                .Ingredients
                .Select(x => x.ToIngredient());
        }

        public IEnumerable<Ingredient> FindAllByIds(IEnumerable<IngredientId> ids)
        {
            var idsString = ids.Select(x => x.Id);
            return _context
                .Ingredients
                .Where(x => idsString.Contains(x.IngredientKey))
                .Include(x => x.Recipes)
                .Select(x => x.ToIngredient());
        }

        public Ingredient Save(Ingredient ingredient)
        {
            return _context.Ingredients.Add(ingredient.State).Entity.ToIngredient();
        }
    }
}