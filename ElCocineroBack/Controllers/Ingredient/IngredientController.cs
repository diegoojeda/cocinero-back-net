using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<IngredientResponseDto>> GetAllIngredientsAsync()
        {
            return (await _ingredientService.FindAllAsync())
                .Select<Domain.Ingredient.Ingredient, IngredientResponseDto>(x => x);
        }

        [HttpPost]
        [ProducesResponseType(typeof(IngredientResponseDto), 200)]
        public async Task<IngredientResponseDto> SaveIngredientAsync([FromBody] CreateIngredientRequestDto body)
        {
            return (await _ingredientService.SaveAsync(body));
        }
    }
}