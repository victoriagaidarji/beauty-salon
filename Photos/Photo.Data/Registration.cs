using System.Runtime.InteropServices.JavaScript;

namespace Photo.Data;

public class Registration: BaseModel
{
    public Client Client { get; set; }
    public DateTime Time { get; set; } 
    public Genre Genre { get; set; }
    public DateOnly Date { get; set; } 
    public int Count { get; set; }
}