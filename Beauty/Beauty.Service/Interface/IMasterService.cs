using Beauty.Data;
using Beauty.Service.ModelsRequest;

namespace Beauty.Service.Interface
{
    public interface IMasterService : IBaseService<Master, MasterRequest>
    {
        Task<List<Master>> GetMastersBySpecialization(string specialization, CancellationToken cancellationToken);
    }
}