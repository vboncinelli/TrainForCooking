using Microsoft.EntityFrameworkCore;
using TrainForCooking.Common;
using TrainForCooking.Dto;
using TrainForCooking.Interfaces;

namespace TrainForCooking.Repository.EF
{
    public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
    {
        public override Recipe? Find(int id)
        {
            try
            {
                return _context
                    .Set<Recipe>()
                    .Include(e => e.Category)
                    .Include(e => e.Cuisine)
                    .Include(e => e.RecipeIngredients)
                    .ThenInclude(ri => ri.Ingredent)
                    .FirstOrDefault(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Something went wrong while accessing the data", ex);
            }
        }

        public override async Task<Recipe?> FindAsync(int id)
        {
            try
            {
                return await _context
                    .Set<Recipe>()
                    .Include(e => e.Category)
                    .Include(e => e.Cuisine)
                    .Include(e => e.RecipeIngredients)
                    .ThenInclude(ri => ri.Ingredent)
                    .FirstOrDefaultAsync(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Something went wrong while accessing the data", ex);
            }
        }

        public PagedCollection<Recipe> GetRecipesByCategoryId(int categoryId, int page, int pageSize)
        {
            try
            {
                var query = GetBaseQueryForList(categoryId: categoryId);

                var count = query.Count();

                var recipes = query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                return new()
                {
                    Items = recipes,
                    Page = page,
                    PageSize = pageSize,
                    TotalItemCount = count
                };

            }
            catch (Exception ex)
            {
                throw new DataAccessException("Something went wrong while accessing the data", ex);
            }
        }

        public async Task<PagedCollection<Recipe>> GetRecipesByCategoryIdAsync(int categoryId, int page, int pageSize)
        {
            try
            {
                var query = this.GetBaseQueryForList(categoryId);

                var count = await query.CountAsync();

                var recipes = await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return new()
                {
                    Items = recipes,
                    Page = page,
                    PageSize = pageSize,
                    TotalItemCount = count
                };

            }
            catch (Exception ex)
            {
                throw new DataAccessException("Something went wrong while accessing the data", ex);
            }
        }

        public PagedCollection<Recipe> GetRecipesByCuisineId(int cuisineId, int page, int pageSize)
        {
            try
            {
                var query = GetBaseQueryForList(cuisineId: cuisineId);

                var count = query.Count();

                var recipes = query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                return new()
                {
                    Items = recipes,
                    Page = page,
                    PageSize = pageSize,
                    TotalItemCount = count
                };
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Something went wrong while accessing the data", ex);
            }
        }

        public async Task<PagedCollection<Recipe>> GetRecipesByCuisineIdAsync(int cuisineId, int page, int pageSize)
        {
            try
            {
                var query = GetBaseQueryForList(cuisineId: cuisineId);

                var count = await query.CountAsync();

                var recipes = await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return new()
                {
                    Items = recipes,
                    Page = page,
                    PageSize = pageSize,
                    TotalItemCount = count
                };
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Something went wrong while accessing the data", ex);
            }
        }

        public PagedCollection<Recipe> GetRecipesByCategoryAndCuisine(int page, int pageSize, int? categoryId = null, int? cuisineId = null)
        {
            try
            {
                IQueryable<Recipe> query = GetBaseQueryForList(categoryId, cuisineId);

                var count = query.Count();

                var recipes = query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                return new()
                {
                    Items = recipes,
                    Page = page,
                    PageSize = pageSize,
                    TotalItemCount = count
                };

            }
            catch (Exception ex)
            {
                throw new DataAccessException("Something went wrong while accessing the data", ex);
            }
        }

        public async Task<PagedCollection<Recipe>> GetRecipesByCategoryAndCuisineAsync(int page, int pageSize, int? categoryId = null, int? cuisineId = null)
        {
            try
            {
                IQueryable<Recipe> query = GetBaseQueryForList(categoryId, cuisineId);

                var count = await query.CountAsync();

                var recipes = await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return new()
                {
                    Items = recipes,
                    Page = page,
                    PageSize = pageSize,
                    TotalItemCount = count
                };

            }
            catch (Exception ex)
            {
                throw new DataAccessException("Something went wrong while accessing the data", ex);
            }
        }

        private IQueryable<Recipe> GetBaseQueryForList(int? categoryId = null, int? cuisineId = null)
        {
            var query = _context
                .Set<Recipe>()
                .AsQueryable();

            if (categoryId is not null)
                query = query.Where(e => e.CategoryId == categoryId);

            if (cuisineId is not null)
                query = query.Where(e => e.CuisineId == cuisineId);

            return query;
        }
    }
}