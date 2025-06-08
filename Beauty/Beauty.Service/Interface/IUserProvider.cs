using Beauty.Data;

namespace Beauty.Service.Interface
{
    public interface IUserProvider : IBaseProvider<User>
    {
        Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken);
        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
    }
}