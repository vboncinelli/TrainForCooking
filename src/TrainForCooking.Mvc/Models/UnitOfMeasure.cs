using System.ComponentModel.DataAnnotations;

namespace TrainForCooking.Mvc.Models
{
    public enum UnitOfMeasure
    {
        [Display(Description = "kg")]
        Kg,
        [Display(Description = "gr")]
        Gram,
        [Display(Description = "l")]
        Liter,
        [Display(Description = "ml")]
        Milliliter,
        [Display(Description = "cup")]
        Cup,
        [Display(Description = "tbsp")]
        Tablespoon,
        [Display(Description = "tsp")]
        Teaspoon
    }
}