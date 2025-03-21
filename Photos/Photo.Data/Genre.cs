namespace Photo.Data;

public class Genre: BaseModel
{
    public Genre(string name)
    {
        Name = name;
    }
    public string Name { get; set; }  
    public string Description { get; set; }  
    public decimal Price { get; set; }
    public List<Registration> Registrations { get; set; }
}