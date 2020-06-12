using System.Collections.Generic;
using System.Linq;
using ElCocineroBack.Controllers.Ingredient.Request;
using ElCocineroBack.Controllers.Ingredient.Response;
using ElCocineroBack.Domain.Ingredient;
using Microsoft.AspNetCore.Mvc;

namespace ElCocineroBack.Controllers.Ingredient
{
    [Route("/api/ingredient")]
    [Produces("application/json")]
    [ApiController]
    public class IngredientController
    {
        private readonly IngredientService _ingredientService;

        public IngredientController(IngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<IngredientResponseDto>), 200)]
        public IEnumerable<IngredientResponseDto> GetAllIngredients()
        {
            return _ingredientService.FindAll()
                .Select<Domain.Ingredient.Ingredient, IngredientResponseDto>(x => x);
        }

        [HttpPost]
        [ProducesResponseType(typeof(IngredientResponseDto), 200)]
        public IngredientResponseDto SaveIngredient([FromBody] CreateIngredientRequestDto body)
        {
            return _ingredientService.Save(body);
        }
    }
}