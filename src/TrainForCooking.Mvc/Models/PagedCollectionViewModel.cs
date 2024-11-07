namespace TrainForCooking.Mvc.Models
{
    public class PagedCollectionViewModel<TEntity>
    {
        public List<TEntity> Items { get; set; } = [];

        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalItemCount { get; set; }
    }
}
