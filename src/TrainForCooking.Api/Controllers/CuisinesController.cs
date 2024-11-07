using Microsoft.AspNetCore.Mvc;
using TrainForCooking.Interfaces;

namespace TrainForCooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuisinesController : ControllerBase
    {
        private readonly ICuisineRepository _cuisineRepository;

        public CuisinesController(ICuisineRepository cuisineRepository)
        {
            _cuisineRepository = cuisineRepository;
        }

        //TODO: Metodo (GET) per recuperare l'elenco delle categorie
    }
}
