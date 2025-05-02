namespace Beauty.Data;

public class MasterProfessionalService
{
    public Guid MasterId { get; set; }
    public Master Master { get; set; }

    public Guid ProfessionalServiceId { get; set; }
    public ProfessionalService ProfessionalService { get; set; }
}
