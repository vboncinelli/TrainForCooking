using Microsoft.AspNetCore.Mvc;
using TrainForCooking.Dto;
using TrainForCooking.Interfaces;

namespace TrainForCooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeRepository _repo;

        public RecipesController(IRecipeRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetRecipe(int id)
        {
            var recipe = _repo.Find(id);

            return Ok(recipe);
        }
    }
}
