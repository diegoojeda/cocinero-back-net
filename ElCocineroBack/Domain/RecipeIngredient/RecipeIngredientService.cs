using System.Collections.Generic;

namespace ElCocineroBack.Domain.RecipeIngredient
{
    public class RecipeIngredientService
    {
        private readonly IRecipeIngredientRepository _recipeIngredientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RecipeIngredientService(IRecipeIngredientRepository recipeIngredientRepository, IUnitOfWork unitOfWork)
        {
            _recipeIngredientRepository = recipeIngredientRepository;
            _unitOfWork = unitOfWork;
        }

        // public void SaveAll(IEnumerable<RecipeIngredient> ingredients)
        // {
        //     _recipeIngredientRepository.SaveAll(ingredients);
        // }
    }
}