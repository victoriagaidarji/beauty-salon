namespace Beauty.Data;

public class Master : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string Specialization { get; set; } = string.Empty;
    public int Experience { get; set; } // в годах
    public string PhotoUrl { get; set; } = string.Empty;
    public List<MasterService> MasterServices { get; set; } = new List<MasterService>();
    public List<Appointment> Appointments { get; set; } = new List<Appointment>();
}