namespace Beauty.Data;

public class MasterProcedure
{
    public Guid MasterId { get; set; }
    public Master Master { get; set; }

    public Guid ProcedureId { get; set; }
    public Procedure Procedure { get; set; }
}
