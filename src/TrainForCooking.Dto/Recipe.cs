using TrainForCooking.Common;

namespace TrainForCooking.Dto
{
    public class Recipe : BaseEntity
    {
        public required string Title { get; set; }

        public required string Author { get; set; }

        public List<Ingredient> Ingredients { get; set; } = [];

        public required string Instructions { get; set; }

        public int? CookingTimeInMinutes { get; set; }

        public required int PreparationTimeInMinutes { get; set; }

        public required int CuisineId { get; set; }

        public Cuisine? Cuisine { get; set; }

        public required int CategoryId { get; set; }

        public Category? Category { get; set; }

        public PriceLevel PriceLevel { get; set; } = PriceLevel.Medium;

        public string? ImageUrl { get; set; }

        public Difficulty Difficulty { get; set; } = Difficulty.Medium;
    }
}
