namespace Beauty.Data;

public class Appointment : BaseModel
{
    public int UserId { get; set; }
    public User User { get; set; }
    public int MasterId { get; set; }
    public Master Master { get; set; }
    public int ServiceId { get; set; }
    public ProfessionalService ProfessionalService { get; set; }
    public DateTime DateTime { get; set; }
    public string Status { get; set; } = "Запланирована";
    public Payment Payment { get; set; }
}