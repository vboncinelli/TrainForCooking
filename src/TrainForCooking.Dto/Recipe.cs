using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainForCooking.Dto
{
    public class Recipe
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public Dictionary<string, string> Ingredients { get; set; } = [];

        public required string Instructions { get; set; }

        public int? CookingTimeInMinutes { get; set; }

        public required int PreparationTimeInMinutes { get; set; }

        public required int CuisineId { get; set; }

        public Cuisine? Cuisine { get; set; }
       
        public required int CategoryId { get; set; }
        
        public Category? Category { get; set; }
    }
}
