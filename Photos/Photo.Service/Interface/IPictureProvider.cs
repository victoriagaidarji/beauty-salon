using Photo.Data;
namespace Photo.Service.Interface;

public interface IPictureProvider:IBaseProvider<Picture>
{
    Task<List<Data.Picture>> GetAllAsyncByRegistration(Registration registration, CancellationToken cancellationToken); 
}