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

        public async Task<IActionResult> Index()
        {
            var cuisines = await _recipeService.
            return View();
        }
    }
}
