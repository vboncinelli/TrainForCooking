using Microsoft.AspNetCore.Mvc;

namespace TrainForCooking.Mvc.Controllers
{
    public class AboutUsController : Controller
    {
        [ViewData]
        public string Title { get; set; }

        public IActionResult Index()
        {
            Title = "My Team";

            List<string> team = [];
            team.Add("Giuseppe");
            team.Add("Antony");
            team.Add("Bruna");
            team.Add("Simone");
            team.Add("Mattia");
            team.Add("Kristin");
            team.Add("Anna");
            team.Add("Annalisa");
            team.Add("Angelo");
            team.Add("Esperanza");
            team.Add("Karolina");
            team.Add("Vanni");

            ViewData["TeamName"] = "Super Train Cooking Team";
            ViewData["MyNumber"] = 12;

            return View(team);
        }
    }
}
