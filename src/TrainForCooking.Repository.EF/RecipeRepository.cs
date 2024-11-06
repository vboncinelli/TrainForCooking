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
                var query = _context
                    .Set<Recipe>()
                    .Where(e => e.CategoryId == categoryId)
                    .AsQueryable();

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
                var query = _context
                    .Set<Recipe>()
                    .Where(e => e.CategoryId == categoryId)
                    .AsQueryable();

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
                var query = _context
                    .Set<Recipe>()
                    .Where(e => e.CuisineId == cuisineId)
                    .AsQueryable();

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
                var query = _context
                    .Set<Recipe>()
                    .Where(e => e.CuisineId == cuisineId)
                    .AsQueryable();

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
    }
}