using Beauty.Data;
using Beauty.Service.ModelsRequest;

namespace Beauty.Service.Interface
{
    public interface IUserService : IBaseService<User, UserRequest>
    {
        Task<User?> GetByUsername(string username, CancellationToken cancellationToken);
    }
}