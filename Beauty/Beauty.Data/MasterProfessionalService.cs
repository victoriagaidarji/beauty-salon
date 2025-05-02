namespace Beauty.Data;

public class MasterProfessionalService
{
    public int MasterId { get; set; }
    public Master Master { get; set; }
    public int ServiceId { get; set; }
    public ProfessionalService ProfessionalService { get; set; }
}