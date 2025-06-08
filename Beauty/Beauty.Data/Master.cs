namespace Beauty.Data;

public class Master : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string Specialization { get; set; } = string.Empty;
    public int Experience { get; set; } // в годах
    public string PhotoUrl { get; set; } = string.Empty;
    public List<MasterProcedure> MasterServices { get; set; } = new List<MasterProcedure>();
    public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    public bool IsActive { get; set; }
}