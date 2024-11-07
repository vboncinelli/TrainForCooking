using Microsoft.AspNetCore.Mvc;
using TrainForCooking.Interfaces;

namespace TrainForCooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeRepository _repo;

        public RecipesController(IRecipeRepository repo, IConfiguration configuration)
        {
            _repo = repo;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRecipeAsync(int id)
        {
            var recipe = await _repo.FindAsync(id);

            if (recipe is null)
                return NotFound();

            return Ok(recipe);
        }

        [HttpGet]
        public async Task<IActionResult> GetRecipesAsync([FromQuery] int page, int pageSize, int? categoryId = null, int? cuisineId = null)
        {
            var recipes = await _repo.GetRecipesByCategoryAndCuisineAsync(page, pageSize, categoryId, cuisineId);

            return Ok(recipes);
        }
        // TODO:
        // 1 - Implementare uno o più metodi che restituiscano una lista di ricette (get)
        //     Ci sono almeno due opzioni:
        //     a) metodo per recuperare l'elenco delle ricette non filtrate per cateoria/cuisine 
        //     b) metodo che accetta due parametri entrambi opzionali, uno per categoria e uno per cuisine
        //
        // 2 - Opzionale: Implementare un metodo per creare una ricetta (post)
        // PS: Preferire, dove possibile, metodi asincroni (async, await, task)

    }
}
