using Beauty.Data;
using Beauty.Service.ModelsRequest;

namespace Beauty.Service.Interface
{
    public interface ISalonService : IBaseService<Salon, SalonRequest>
    {
        Task<Salon?> GetByAddress(string address, CancellationToken cancellationToken);
    }
}