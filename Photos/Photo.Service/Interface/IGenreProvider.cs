using Photo.Data;

namespace Photo.Service.Interface;

public interface IGenreProvider:IBaseProvider<Genre>
{
    Task<Genre?> FindAsync(string name, CancellationToken cancellationToken);
}