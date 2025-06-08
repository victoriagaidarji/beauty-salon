namespace Beauty.Service.ModelsRequest
{
    public class PaymentRequest : BaseModelRequest
    {
        public Guid AppointmentId { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Status { get; set; } = "Ожидает";
    }
}