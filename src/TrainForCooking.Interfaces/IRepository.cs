using TrainForCooking.Dto;

namespace TrainForCooking.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
    }
}
