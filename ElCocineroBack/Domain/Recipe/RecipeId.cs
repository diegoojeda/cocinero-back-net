using System.ComponentModel.DataAnnotations.Schema;
using ElCocineroBack.Domain.ValueObjects;

namespace ElCocineroBack.Domain.Recipe
{
    [ComplexType]
    public class RecipeId : Identity
    {
        public RecipeId()
        {
        }

        public RecipeId(string id) : base(id)
        {
        }
    }
}