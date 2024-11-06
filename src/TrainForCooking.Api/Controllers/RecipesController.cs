using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainForCooking.Dto;

namespace TrainForCooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        [HttpGet("{id:int}")]
        public IActionResult GetRecipe(int id)
        {
            if (id == 4)
            {
                return NotFound();
            }

            var category = new Category() { Id = 1, Name = "Primi Piatti" };
            var cusine = new Cuisine() { Id = 1, Name = "Italiana" };

            var ingredients = new List<Ingredient>
            {
                new() {Id = 1, Name = "Spaghetti", Quantity = 400, UnitOfMeasure = UnitOfMeasure.Gram }

            };

            var recipe = new Recipe()
            {
                Id = id,
                Title = "Spaghetti alla carbonara",
                CategoryId = category.Id,
                Category = category,
                Cuisine = cusine,
                CuisineId = cusine.Id,
                CookingTimeInMinutes = 10,
                PreparationTimeInMinutes = 20,
                Ingredients = ingredients,
                Instructions = "Cuocere gli spaghetti in acqua bollente..."
            };

            return Ok(recipe);
        }
    }
}
