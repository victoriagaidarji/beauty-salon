using AutoMapper;
using Beauty.Data;
using Beauty.Service.Interface;
using Beauty.Service.ModelsRequest;

namespace Beauty.Service;

public class MasterService : BaseService<Master, MasterRequest, IMasterProvider>, IMasterService
{
    private IMasterProvider _provider;
    private IMapper _mapper;

    public MasterService(IMasterProvider provider, IMapper mapper) : base(provider, mapper)
    {
        _provider = provider;
        _mapper = mapper;
    }

    public Task<Guid> CreateAsync(ProfessionalServiceRequest entityRequest, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Master> UpdateAsync(ProfessionalServiceRequest entityRequest, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<Master>> GetByCategory(string category, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
