using Photo.Data;
using Photo.Service.ModelRequest; 


namespace Photo.Service.Interface;

public interface IPictureService: IBaseService<Data.Picture, PictureRequest>
{
    Task<List<Data.Picture>> GetAllAsync(Registration registration, CancellationToken cancellationToken); 
}