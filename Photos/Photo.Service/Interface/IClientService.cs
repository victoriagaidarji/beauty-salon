using Photo.Data;
using Photo.Service.ModelRequest;

namespace Photo.Service.Interface;

public interface IClientService: IBaseService<Client, ClientRequest>
{
    Task<Client> GetByClientName(string name, CancellationToken cancellationToken);
}