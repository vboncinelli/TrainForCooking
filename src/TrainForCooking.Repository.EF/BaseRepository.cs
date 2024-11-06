using Microsoft.EntityFrameworkCore;
using TrainForCooking.Common;
using TrainForCooking.Dto;
using TrainForCooking.Interfaces;

namespace TrainForCooking.Repository.EF
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {

        protected readonly RecipesContext _context;

        private bool _disposed = false;

        public BaseRepository()
        {
            _context = new RecipesContext();

            _context.Database.EnsureCreated();
        }

        /// <summary>
        /// Retrieves an entity with the specified Id from the database.
        /// </summary>
        /// <param name="id">The Id of the entity to retrieve.</param>
        /// <returns>The entity with the specified Id, or null if no such entity exists.</returns>
        public virtual async Task<TEntity?> FindAsync(int id)
        {
            try
            {
                return await _context.Set<TEntity>().FindAsync(id);

            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Retrieves an entity with the specified Id from the database.
        /// </summary>
        /// <param name="id">The Id of the entity to retrieve.</param>
        /// <returns>The entity with the specified Id, or null if no such entity exists.</returns>
        public virtual TEntity? Find(int id)
        {
            try
            {
                return _context.Set<TEntity>().Find(id);

            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Checks if an entity with the given id exists in the database.
        /// </summary>
        /// <param name="id">The id of the entity to check.</param>
        /// <returns>True if the entity exists, false otherwise.</returns>
        public virtual async Task<bool> ExistsAsync(int key)
        {
            try
            {
                return await FindAsync(key) is not null;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Checks if an entity with the given id exists in the database.
        /// </summary>
        /// <param name="id">The id of the entity to check.</param>
        /// <returns>True if the entity exists, false otherwise.</returns>
        public virtual bool Exists(int key)
        {
            try
            {
                return Find(key) is not null;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Inserts an entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        /// <returns>The inserted entity.</returns>
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            try
            {
                var attached = _context.Set<TEntity>().Attach(entity);

                attached.State = EntityState.Added;

                await _context.SaveChangesAsync();

                return entity;

            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Inserts an entity synchronously.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        /// <returns>The inserted entity.</returns>
        public virtual TEntity Add(TEntity entity)
        {
            try
            {
                var attached = _context.Set<TEntity>().Attach(entity);

                attached.State = EntityState.Added;

                _context.SaveChanges();

                return entity;

            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Updates an entity in the database asynchronously.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            try
            {
                var attached = _context.Set<TEntity>().Attach(entity);

                attached.State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }


        /// <summary>
        /// Updates an entity in the database synchronously.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        public virtual TEntity Update(TEntity entity)
        {
            try
            {
                var attached = _context.Set<TEntity>().Attach(entity);

                attached.State = EntityState.Modified;

                _context.SaveChanges();

                return entity;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Asynchronously deletes an entity with the specified id.
        /// </summary>
        /// <param name="id">The id of the entity to delete.</param>
        /// <returns>A task that represents the asynchronous delete operation.</returns>
        public virtual async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await _context.Set<TEntity>().Where(e => e.Id == id).FirstOrDefaultAsync();

                if (entity is null)
                    throw new EntityNotFoundException($"{nameof(TEntity)} with id {id} not found");

                _context.Set<TEntity>().Attach(entity).State = EntityState.Deleted;

                await _context.SaveChangesAsync();
            }
            catch (EntityNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Synchronously deletes an entity with the specified id.
        /// </summary>
        /// <param name="id">The id of the entity to delete.</param>
        public virtual void Delete(int id)
        {
            try
            {
                var entity = _context.Set<TEntity>().Where(e => e.Id == id).FirstOrDefault();

                if (entity is null)
                    throw new EntityNotFoundException($"{nameof(TEntity)} with id {id} not found");

                _context.Set<TEntity>().Attach(entity).State = EntityState.Deleted;

                _context.SaveChanges();
            }
            catch (EntityNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Counts the number of entities in the database asynchronously.
        /// </summary>
        /// <returns>The number of entities in the database.</returns>
        public virtual async Task<int> CountAsync()
        {
            try
            {
                return await _context.Set<TEntity>().CountAsync();
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Counts the number of entities in the database synchronously.
        /// </summary>
        /// <returns>The number of entities in the database.</returns>
        public virtual int Count()
        {
            try
            {
                return _context.Set<TEntity>().Count();
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }


        /// <summary>
        /// Retrieves a paginated collection of entities from the database.
        /// </summary>
        /// <param name="page">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A paginated collection of entities.</returns>
        public virtual async Task<PagedCollection<TEntity>> GetAllAsync(int page = 1, int pageSize = 100, bool ascending = true)
        {
            try
            {

                var query = _context.Set<TEntity>().AsQueryable();

                query = ascending ? query.OrderBy(e => e.Id) : query.OrderByDescending(e => e.Id);

                var entities = await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync<TEntity>();

                var count = await _context.Set<TEntity>().CountAsync();

                return new PagedCollection<TEntity>
                {
                    Items = entities,
                    Page = page,
                    PageSize = pageSize,
                    TotalItemCount = count
                };
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Retrieves a paginated collection of entities from the database.
        /// </summary>
        /// <param name="page">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A paginated collection of entities.</returns>
        public virtual PagedCollection<TEntity> GetAll(int page = 1, int pageSize = 100, bool ascending = true)
        {
            try
            {

                var query = _context.Set<TEntity>().AsQueryable();

                query = ascending ? query.OrderBy(e => e.Id) : query.OrderByDescending(e => e.Id);

                var entities = query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList<TEntity>();

                var count = _context.Set<TEntity>().Count();

                return new PagedCollection<TEntity>
                {
                    Items = entities,
                    Page = page,
                    PageSize = pageSize,
                    TotalItemCount = count
                };
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message, ex);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context?.Dispose();
                }

                _disposed = true;
            }
        }

        // Implement IDisposable
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
    }
}
