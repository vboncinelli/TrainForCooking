using TrainForCooking.Mvc.Models;

namespace TrainForCooking.Mvc.Services
{
    public interface IRecipeService
    {
        Task<RecipeViewModel?> GetRecipeAsync(int id);

        Task<PagedCollectionViewModel<CategoryViewModel>> GetCategoriesAsync(int page, int pageSize);
    }
}
