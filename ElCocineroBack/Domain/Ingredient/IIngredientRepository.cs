using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElCocineroBack.Domain.Ingredient
{
    public interface IIngredientRepository
    {
        IEnumerable<Ingredient> FindAll();
        IEnumerable<Ingredient> FindAllByIds(IEnumerable<IngredientId> ids);
        Ingredient Save(Ingredient ingredient);
    }
}