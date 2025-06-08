using AutoMapper;
using Beauty.Data;
using Beauty.Service.Interface;
using Beauty.Service.ModelsRequest;

namespace Beauty.Service
{
    public class UserService : BaseService<User, UserRequest, IUserProvider>, IUserService
    {
        private readonly IUserProvider _provider;
        private readonly IMapper _mapper;

        public UserService(IUserProvider provider, IMapper mapper) : base(provider, mapper)
        {
            _provider = provider;
            _mapper = mapper;
        }

        public async Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken)
        {
            return await _provider.GetByUsernameAsync(username, cancellationToken);
        }

        public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _provider.GetByEmailAsync(email, cancellationToken);
        }
    }
}