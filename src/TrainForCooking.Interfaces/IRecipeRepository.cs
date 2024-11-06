using TrainForCooking.Dto;

namespace TrainForCooking.Interfaces
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        PagedCollection<Recipe> GetRecipesByCategoryId(int categoryId, int page, int pageSize);

        Task<PagedCollection<Recipe>> GetRecipesByCategoryIdAsync(int categoryId, int page, int pageSize);

        PagedCollection<Recipe> GetRecipesByCuisineId(int cuisineId, int page, int pageSize);

        Task<PagedCollection<Recipe>> GetRecipesByCuisineIdAsync(int cuisineId, int page, int pageSize);
    }
}
