using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElCocineroBack.Domain.Ingredient
{
    public interface IIngredientRepository
    {
        Task<IEnumerable<Ingredient>> FindAllAsync();
        Task<Ingredient> SaveAsync(Ingredient ingredient);
    }
}