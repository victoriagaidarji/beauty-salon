using AutoMapper;
using Photo.Service.CustomException;
using Photo.Data;
using Photo.Service.CustomException;
using Photo.Service.Interface;
using Photo.Service.ModelRequest;

namespace Photo.Service;

public class ClientService : BaseService<Client, ClientRequest, IClientProvider>, IClientService

{
    private readonly IClientProvider _clientProvider;
    private IMapper _mapper;
    public ClientService(IClientProvider provider, IMapper mapper) : base(provider, mapper)
    {
        _clientProvider = provider;
        _mapper = mapper;
    }

    public async Task<Client> GetByClientName(string name, CancellationToken cancellationToken)
    {
        var clients = await _clientProvider.GetAllAsync(new CancellationToken());
        var client = clients.FirstOrDefault(c => c.Name == name);
        return client;
    }
}