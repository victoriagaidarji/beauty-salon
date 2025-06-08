using Beauty.Data;

namespace Beauty.Service.Interface
{
    public interface IProcedureProvider : IBaseProvider<Procedure>
    {
        Task<List<Procedure>> GetByCategoryAsync(string category, CancellationToken cancellationToken);
        Task<List<Procedure>> GetByNameAsync(string name, CancellationToken cancellationToken);
    }
}