namespace TrainForCooking.Dto
{
    public class PagedCollection<TEntity>
        where TEntity : BaseEntity
    {
        public List<TEntity> Items { get; set; } = [];

        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalItemCount { get; set; }
    }
}
