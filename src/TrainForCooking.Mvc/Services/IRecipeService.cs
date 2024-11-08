using TrainForCooking.Mvc.Models;

namespace TrainForCooking.Mvc.Services
{
    public interface IRecipeService
    {
        Task<RecipeViewModel?> GetRecipeAsync(int id);

        Task<PagedCollectionViewModel<RecipeViewModel>> GetRecipesAsync(int page, int pageSize, int? categoryId = null, int? cuisineId = null);

        Task<PagedCollectionViewModel<CategoryViewModel>> GetCategoriesAsync(int page, int pageSize);
        
        Task<PagedCollectionViewModel<CuisineViewModel>> GetCuisinesAsync(int page, int pageSize);

    }
}
