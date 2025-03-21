using Photo.Data;

namespace Photo.Service.Interface;

public interface IClientProvider:IBaseProvider<Client>
{
    Task<Client?> FindAsync(string phone, CancellationToken cancellationToken);
}