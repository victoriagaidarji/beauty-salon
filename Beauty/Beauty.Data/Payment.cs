namespace Beauty.Data;

public class Payment : BaseModel
{
    public Guid AppointmentId { get; set; }
    public Appointment Appointment { get; set; }

    public string PaymentMethod { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Status { get; set; } = "Ожидает";
}
