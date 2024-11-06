using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace TrainForCooking.Common
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            var attribute = field?.GetCustomAttribute<DisplayAttribute>();
            
            return attribute?.Description ?? value.ToString();
        }
    }
}
