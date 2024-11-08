using Microsoft.AspNetCore.Mvc;
using RestSharp;
using TrainForCooking.Mvc.Models;
using TrainForCooking.Mvc.Services;

namespace TrainForCooking.Mvc.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        // GET: Recipes
        public async Task<ActionResult> List([FromQuery] int page = 1, int pageSize = 20, int? categoryId = null, int? cuisineId = null)
        {
            var recipes = await _recipeService.GetRecipesAsync(page, pageSize, categoryId, cuisineId);

            return View(recipes);
        }

        // GET: Recipe/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var recipe = await _recipeService.GetRecipeAsync(id);

                //TODO: Cosa fare se recipe è null perché non esiste una ricetta con quell'id?
                if (recipe is null)
                    RedirectToAction("Error", "Home", new ErrorViewModel
                    {
                        Message = $"Recipe with id {id} not found.",
                        Code = "404"
                    });

                return View(recipe);
            }
            catch (Exception ex)
            {
                // TODO: Testare se funziona in caso di errore... o trovare un'alternativa
                // es. redirect verso un'altra azione (quale?)

                return RedirectToAction("Home", "Error", new ErrorViewModel
                {
                    RequestId = HttpContext.TraceIdentifier,
                    Message = "Something went wrong during the operation..."
                });
            };
        }

        // GET: Recipe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var recipe = new RecipeViewModel
                    {
                        Title = collection["Title"]!,
                        Author = collection["Author"]!,
                        CategoryId = int.Parse(collection["CategoryId"]!),
                        CuisineId = int.Parse(collection["CuisineId"]!),
                        Difficulty = (Difficulty)Enum.Parse(typeof(Difficulty), collection["Difficulty"]!),
                        CookingTimeInMinutes = int.Parse(collection["CookingTimeInMinutes"]),
                        PriceLevel = (PriceLevel)Enum.Parse(typeof(PriceLevel), collection["PriceLevel"]!),
                        Instructions = collection["Instructions"]!,
                        PreparationTimeInMinutes = int.Parse(collection["PreparationTimeInMinutes"]),
                        ImageUrl = collection["ImageUrl"]
                    };
                    // Save the recipe to the database or perform other actions

                    var created = await _recipeService.CreateRecipeAsync(recipe);

                    return RedirectToAction("Index");
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RecipeController/Edit/5
        public ActionResult Edit(int id)
        {
            // TODO (Opzionale): consentire all'utente di modificare la ricetta

            return View();
        }

        // POST: RecipeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO (Opzionale): consentire all'utente di modificare la ricetta

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
