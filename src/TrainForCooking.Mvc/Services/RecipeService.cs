using RestSharp;
using TrainForCooking.Mvc.Models;

namespace TrainForCooking.Mvc.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly RestClient _client;

        public RecipeService(IConfiguration configuration)
        { 
            var apiUrl = configuration["apiUrl"] ?? throw new ArgumentNullException("Check your appsettings.json file ;)");

            var options = new RestClientOptions(apiUrl);

            _client = new RestClient(options);
        }

        public async Task<RecipeViewModel?> GetRecipeAsync(int id)
        {
            try
            {
                var request = new RestRequest($"recipes/{id}");

                return await _client.GetAsync<RecipeViewModel>(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task<PagedCollectionViewModel<RecipeViewModel>> GetRecipesAsync(int page, int pageSize, int? categoryId = null, int? cuisineId = null)
        {
            try
            {
                var request = new RestRequest($"recipes?page={page}&pageSize={pageSize}&categoryId={categoryId}&cuisineId={cuisineId}");

                var result = await _client.GetAsync<PagedCollectionViewModel<RecipeViewModel>>(request);

                return result ?? new PagedCollectionViewModel<RecipeViewModel>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PagedCollectionViewModel<CategoryViewModel>> GetCategoriesAsync(int page, int pageSize)
        {
            try
            { 
                var request = new RestRequest($"categories?page={page}&pageSize={pageSize}");

                var result  = await _client.GetAsync<PagedCollectionViewModel<CategoryViewModel>>(request);

                return result ?? new PagedCollectionViewModel<CategoryViewModel>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PagedCollectionViewModel<CuisineViewModel>> GetCuisinesAsync(int page, int pageSize)
        {
            try
            {
                var request = new RestRequest($"cuisines?page={page}&pageSize={pageSize}");

                var result = await _client.GetAsync<PagedCollectionViewModel<CuisineViewModel>>(request);

                return result ?? new PagedCollectionViewModel<CuisineViewModel>();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
