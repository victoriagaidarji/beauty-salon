using Beauty.Data;
using Beauty.Service.ModelsRequest;

namespace Beauty.Service.Interface
{
    public interface IMasterService : IBaseService<Master, ProfessionalServiceRequest>
    {
        Task<List<Master>> GetByCategory(string category, CancellationToken cancellationToken);
        
    }
}