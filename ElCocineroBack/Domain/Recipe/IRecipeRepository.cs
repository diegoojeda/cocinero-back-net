using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElCocineroBack.Domain.Recipe
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> FindAllAsync();
        Task<Recipe> SaveAsync(Recipe recipe);
        Task<IEnumerable<Recipe>> FindAllForAuthorAsync(string authorId);
    }
}