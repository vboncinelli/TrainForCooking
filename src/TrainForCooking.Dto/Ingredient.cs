using System.Text.Json.Serialization;
using TrainForCooking.Common;

namespace TrainForCooking.Dto
{
    public class Ingredient
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        [JsonIgnore]
        public int? Quantity { get; set; }

        [JsonIgnore]
        public UnitOfMeasure? UnitOfMeasure { get; set; }

        public string FormattedQuantity => $"{Quantity} {UnitOfMeasure?.GetDescription()}";
    }
}
