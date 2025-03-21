using Photo.Data;
using Photo.Service.ModelRequest;

namespace Photo.Service.Interface;

public interface IRegistrationService: IBaseService<Registration, RegistrationRequest>
{
    Task<List<Registration>> GetByRegistration(Guid clientId, CancellationToken cancellationToken);
}