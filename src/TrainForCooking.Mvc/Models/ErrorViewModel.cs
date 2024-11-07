namespace TrainForCooking.Mvc.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public string? Message { get; set; }

        public string? Code { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
