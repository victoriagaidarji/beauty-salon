using AutoMapper;
using Beauty.Data;
using Beauty.Service.Interface;
using Beauty.Service.ModelsRequest;

namespace Beauty.Service;

public class ProfessionalServiceService : BaseService<ProfessionalService, ProfessionalServiceRequest, IProfessionalServiceProvider>, IProfessionalServiceService
{
    private IProfessionalServiceProvider _provider;
    private IMapper _mapper;

    public ProfessionalServiceService(IProfessionalServiceProvider provider, IMapper mapper) : base(provider, mapper)
    {
        _provider = provider;
        _mapper = mapper;
    }

    public Task<List<ProfessionalService>> GetByCategory(string category, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}