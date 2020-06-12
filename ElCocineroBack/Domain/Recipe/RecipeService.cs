using System.Collections.Generic;

namespace ElCocineroBack.Domain.Recipe
{
    public class RecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RecipeService(IRecipeRepository recipeRepository, IUnitOfWork unitOfWork)
        {
            _recipeRepository = recipeRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Recipe> FindAll()
        {
            return _recipeRepository.FindAll();
        }

        public Recipe Save(Recipe recipe)
        {
            var inserted = _recipeRepository.Save(recipe);
            _unitOfWork.Complete();
            return inserted;
        }

        public IEnumerable<Recipe> FindAllForAuthor(string authorId)
        {
            return _recipeRepository.FindAllForAuthor(authorId);
        }

        public IEnumerable<RecipeIngredient.RecipeIngredient> SaveIngredientsAsync(
            IEnumerable<RecipeIngredient.RecipeIngredient> ingredients)
        {
            _recipeRepository.SaveIngredients(ingredients);
            _unitOfWork.Complete();
            return new List<RecipeIngredient.RecipeIngredient>();//TODO
        }
    }
}