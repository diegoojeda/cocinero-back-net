using System;
using System.Collections.Generic;

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

        public IEnumerable<Ingredient> FindAll()
        {
            return _ingredientRepository.FindAll();
        }

        public Ingredient Save(Ingredient ingredient)
        {
            var inserted = _ingredientRepository.Save(ingredient);
            _unitOfWork.Complete();
            return inserted;
        }

        public void SaveAll(IEnumerable<Ingredient> ingredientsToInsert)
        {
            throw new NotImplementedException();
        }
    }
}