using System.Runtime.InteropServices.JavaScript;

namespace Beauty.Data;

public class Procedure : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Duration { get; set; } // в минутах
    public decimal Price { get; set; }
    public string Category { get; set; } = string.Empty;
    public List<MasterProcedure> MasterServices { get; set; } = new List<MasterProcedure>();
    public List<Appointment> Appointments { get; set; } = new List<Appointment>();
}
