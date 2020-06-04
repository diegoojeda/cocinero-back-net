using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElCocineroBack.Domain.Recipe
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> FindAllAsync();
    }
}