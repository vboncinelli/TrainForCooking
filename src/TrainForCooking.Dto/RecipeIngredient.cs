using System.Text.Json.Serialization;
using TrainForCooking.Common;

namespace TrainForCooking.Dto
{
    public class RecipeIngredient : BaseEntity
    {
        public int RecipeId { get; set; }

        public int IngredientId { get; set; }

        public Ingredient? Ingredent { get; set; }

        [JsonIgnore]
        public int? Quantity { get; set; }

        [JsonIgnore]
        public UnitOfMeasure? UnitOfMeasure { get; set; }

        public string FormattedQuantity => $"{Quantity} {UnitOfMeasure?.GetDescription()}";
    }
}
