using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElCocineroBack.Controllers;

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

        public Task<IEnumerable<Recipe>> FindAllAsync()
        {
            return _recipeRepository.FindAllAsync();
        }

        public Task<Recipe> SaveAsync(Recipe recipe)
        {
            var inserted = _recipeRepository.SaveAsync(recipe);
            _unitOfWork.CompleteAsync();
            return inserted;
        }

        public Task<IEnumerable<Recipe>> FindAllForAuthorAsync(string authorId)
        {
            return _recipeRepository.FindAllForAuthorAsync(authorId);
        }
    }
}