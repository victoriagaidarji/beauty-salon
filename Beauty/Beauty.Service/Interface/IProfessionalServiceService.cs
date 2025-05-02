using Beauty.Data;
using Beauty.Service.ModelsRequest;

namespace Beauty.Service.Interface
{
    public interface IProfessionalServiceService : IBaseService<ProfessionalService, ProfessionalServiceRequest>
    {
        Task<List<Data.ProfessionalService>> GetByCategory(string category, CancellationToken cancellationToken);
    }
}