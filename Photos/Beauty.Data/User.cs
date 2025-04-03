namespace Beauty.Data;

public class User : BaseModel
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public List<Appointment> Appointments { get; set; } = new List<Appointment>();
}