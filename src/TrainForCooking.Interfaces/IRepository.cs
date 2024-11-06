using TrainForCooking.Dto;

namespace TrainForCooking.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        TEntity Add(TEntity entity);

        Task<TEntity> AddAsync(TEntity entity);
        
        int Count();
        
        Task<int> CountAsync();
        
        void Delete(int id);
        
        Task DeleteAsync(int id);
        
        void Dispose();
        
        bool Exists(int key);
        
        Task<bool> ExistsAsync(int key);
        
        TEntity? Find(int id);
        
        Task<TEntity?> FindAsync(int id);
        
        PagedCollection<TEntity> GetAll(int page = 1, int pageSize = 100, bool ascending = true);
        
        Task<PagedCollection<TEntity>> GetAllAsync(int page = 1, int pageSize = 100, bool ascending = true);
        
        TEntity Update(TEntity entity);
        
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
