using Beauty.Data;
using Beauty.Service.ModelsRequest;

namespace Beauty.Service.Interface
{
    public interface ISalonService : IBaseService<Salon, SalonRequest>
    {
        Task<List<Salon>> GetByNameAsync(string name, CancellationToken cancellationToken);
    }
}