using Microsoft.AspNetCore.Mvc;
using TrainForCooking.Mvc.Services;

namespace TrainForCooking.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IRecipeService _recipeService;

        public CategoryController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 20)
        {
            var categories = await _recipeService.GetCategoriesAsync(page, pageSize);

            return View(categories);
        }
    }
}
