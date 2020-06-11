using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElCocineroBack.Domain.Ingredient
{
    public interface IIngredientRepository
    {
        Task<IEnumerable<Ingredient>> FindAllAsync();
        Task<IEnumerable<Ingredient>> FindAllAsync(IEnumerable<IngredientId> ids);
        Task<Ingredient> SaveAsync(Ingredient ingredient);
    }
}