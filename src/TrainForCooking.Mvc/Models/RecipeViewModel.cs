namespace TrainForCooking.Mvc.Models
{
    public class RecipeViewModel
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public required string Author { get; set; }

        public List<RecipeIngredient> RecipeIngredients { get; set; } = [];

        public required string Instructions { get; set; }

        public int? CookingTimeInMinutes { get; set; }

        public required int PreparationTimeInMinutes { get; set; }

        public required int CuisineId { get; set; }

        public CuisineViewModel? Cuisine { get; set; }

        public required int CategoryId { get; set; }

        public CategoryViewModel? Category { get; set; }

        public PriceLevel PriceLevel { get; set; } = PriceLevel.Medium;

        public string? ImageUrl { get; set; }

        public Difficulty Difficulty { get; set; } = Difficulty.Medium;
    }
}
