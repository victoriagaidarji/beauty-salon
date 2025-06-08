using Beauty.Data;
using Beauty.Service.ModelsRequest;

namespace Beauty.Service.Interface
{
    public interface IProcedureService : IBaseService<Procedure, ProcedureRequest>
    {
        Task<List<Procedure>> GetProceduresByCategory(string category, CancellationToken cancellationToken);
        Task<List<Procedure>> GetProceduresByName(string name, CancellationToken cancellationToken);
    }
}