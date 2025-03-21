namespace Photo.Service.ModelRequest;

public class BaseModelRequest
{    public BaseModelRequest()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
    
}