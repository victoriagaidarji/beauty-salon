using AutoMapper;
using Photo.Data;
using Photo.Service.Interface;

namespace Photo.Service.ModelRequest;

public class RegistrationService:BaseService<Registration, RegistrationRequest, IRegistrationProvider>, IRegistrationService
{
    public RegistrationService(IRegistrationProvider provider, IMapper mapper) : base(provider, mapper)
    {
        
    }

    public Task<List<Registration>> GetByRegistration(Guid clientId, CancellationToken cancellationToken)
    {
        
    }
}