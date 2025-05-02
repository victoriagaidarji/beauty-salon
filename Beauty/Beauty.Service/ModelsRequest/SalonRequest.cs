using Beauty.Data;

namespace Beauty.Service.ModelsRequest;

public class SalonRequest : BaseModelRequest
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string WorkingHours { get; set; } = string.Empty;
}