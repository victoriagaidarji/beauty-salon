namespace Photo.Data;

public class Client: BaseModel
{
    public Client(string name, string phone)
    {
        Name = name;
        Phone = phone;
    }

    public string Name { get; set; }  
    public string Phone { get; set; } 
    public List <Registration> Registrations { get; set; }
}