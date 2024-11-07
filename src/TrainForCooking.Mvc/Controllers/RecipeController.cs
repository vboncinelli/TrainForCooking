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

        // GET: RecipeController
        public ActionResult Index()
        {
            // TODO: Chiamare le API per recuperare l'elenco delle ricette
            // Cliccando su una ricetta, andiamo nella pagina di dettaglio

            // TODO (opzionale): Implementare la paginazione

            return View();
        }

        // GET: Recipe/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var recipe = await _recipeService.GetRecipeAsync(id);

                //TODO: Cosa fare se recipe è null perché non esiste una ricetta con quell'id?

                return View(recipe);
            }
            catch (Exception ex)
            {
                // TODO: Testare se funziona in caso di errore... o trovare un'alternativa
                // es. redirect verso un'altra azione (quale?)

                return View("Error", new ErrorViewModel
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

        // POST: RecipeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Salvare la ricetta chiamando le API

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
