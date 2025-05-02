namespace Beauty.Data;

public class Appointment : BaseModel
{
    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid MasterId { get; set; }
    public Master Master { get; set; }

    public Guid ServiceId { get; set; }
    public ProfessionalService ProfessionalService { get; set; }

    public DateTime DateTime { get; set; }
    public string Status { get; set; } = "Запланирована";

    public Payment? Payment { get; set; } // Один к одному
}
