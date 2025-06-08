using Beauty.Data;

namespace Beauty.Service.Interface
{
    public interface ISalonProvider : IBaseProvider<Salon>
    {
        Task<List<Salon>> GetByNameAsync(string name, CancellationToken cancellationToken);
    }
}