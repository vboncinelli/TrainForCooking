using Microsoft.AspNetCore.Mvc;
using TrainForCooking.Dto;
using TrainForCooking.Interfaces;

namespace TrainForCooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        //TODO: Implementare un metodo (GET) per recuperare l'elenco delle categorie

        [HttpGet]
        public async Task<PagedCollection<Category>> GetCategoriesAsync([FromQuery]int page = 1, int pageSize = 20)
        {
            return await _categoryRepository.GetAllAsync(page, pageSize);
        }
    }

}
