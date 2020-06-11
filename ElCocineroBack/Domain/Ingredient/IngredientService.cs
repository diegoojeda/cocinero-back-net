using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElCocineroBack.Controllers.Recipe.Request;

namespace ElCocineroBack.Domain.Ingredient
{
    public class IngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public IngredientService(IIngredientRepository ingredientRepository, IUnitOfWork unitOfWork)
        {
            _ingredientRepository = ingredientRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Ingredient>> FindAllAsync()
        {
            return _ingredientRepository.FindAllAsync();
        }

        public Task<IEnumerable<Ingredient>> FindAllAsync(IEnumerable<IngredientId> ids)
        {
            return _ingredientRepository.FindAllAsync(ids);
        }

        public Task<Ingredient> SaveAsync(Ingredient ingredient)
        {
            var inserted = _ingredientRepository.SaveAsync(ingredient);
            _unitOfWork.CompleteAsync();
            return inserted;
        }

        public void SaveAllAsync(IEnumerable<Ingredient> ingredientsToInsert)
        {
            throw new System.NotImplementedException();
        }
    }
}