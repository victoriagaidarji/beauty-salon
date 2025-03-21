namespace Photo.Data;

public class Portfolio: BaseModel
{
    public string Path { get; set; }  
    public PhotoType PhotoType { get; set; }
    public Genre Genre { get; set; }
}