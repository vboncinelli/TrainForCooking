using System.Text.Json.Serialization;
using TrainForCooking.Common;

namespace TrainForCooking.Mvc.Models
{
    public class RecipeIngredient
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }

        public int IngredientId { get; set; }

        public IngredientViewModel? Ingredent { get; set; }

        public int? Quantity { get; set; }

        public UnitOfMeasure? UnitOfMeasure { get; set; }

        [JsonIgnore]
        public string FormattedQuantity => $"{Quantity} {UnitOfMeasure?.GetDescription()}";
    }
}
