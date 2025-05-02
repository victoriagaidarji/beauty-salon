using AutoMapper;
using Beauty.Data;
using Beauty.Service.Interface;
using Beauty.Service.ModelsRequest;

namespace Beauty.Service;

public class UserService : BaseService<User, UserRequest, IUserProvider>, IUserService
{
    private IUserProvider _provider;
    private IMapper _mapper;

    public UserService(IUserProvider provider, IMapper mapper) : base(provider, mapper)
    {
        _provider = provider;
        _mapper = mapper;
    }

    public Task<User?> GetByUsername(string username, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}


