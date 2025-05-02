using AutoMapper;
using Beauty.Data;
using Beauty.Service.Interface;
using Beauty.Service.ModelsRequest;

namespace Beauty.Service;

public class SalonService : BaseService<Salon, SalonRequest, ISalonProvider>, ISalonService
{
    private ISalonProvider _provider;
    private IMapper _mapper;

    public SalonService(ISalonProvider provider, IMapper mapper) : base(provider, mapper)
    {
        _provider = provider;
        _mapper = mapper;
    }

    public Task<Salon?> GetByAddress(string address, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
