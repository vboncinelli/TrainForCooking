using Microsoft.AspNetCore.Mvc;
using TrainForCooking.Mvc.Services;

namespace TrainForCooking.Mvc.Controllers
{
    public class CuisineController : Controller
    {
        private readonly IRecipeService _recipeService;

        public CuisineController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 20)
        {
            var cuisines = await _recipeService.GetCuisinesAsync(page, pageSize);

            return View(cuisines);
        }
    }
}
