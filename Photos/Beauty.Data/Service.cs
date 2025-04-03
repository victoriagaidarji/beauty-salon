using System.Runtime.InteropServices.JavaScript;

namespace Beauty.Data;

public class Service : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Duration { get; set; } // в минутах
    public decimal Price { get; set; }
    public string Category { get; set; } = string.Empty;
    public List<MasterService> MasterServices { get; set; } = new List<MasterService>();
    public List<Appointment> Appointments { get; set; } = new List<Appointment>();
}