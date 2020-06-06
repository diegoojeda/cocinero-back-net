using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElCocineroBack.Domain.Ingredient;
using Microsoft.AspNetCore.Mvc;

namespace ElCocineroBack.Controllers
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
            return (await _ingredientService.FindAllAsync()).Select<Ingredient, IngredientResponseDto>(x => x);
        }

        [HttpPost]
        [ProducesResponseType(typeof(IngredientResponseDto), 200)]
        public async Task<IngredientResponseDto> SaveIngredientAsync([FromBody] CreateIngredientDto body)
        {
            return (await _ingredientService.SaveAsync(body));
        }
    }

    public class CreateIngredientDto
    {
        public string Name { get; set; }
    }

    public class IngredientResponseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}