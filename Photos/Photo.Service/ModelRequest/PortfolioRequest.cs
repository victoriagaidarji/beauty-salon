using Photo.Data;

namespace Photo.Service.ModelRequest;

public class PortfolioRequest: BaseModelRequest
{
    public string Path { get; set; }  
    public PhotoType PhotoType { get; set; }
    public Guid GenreId { get; set; }
}