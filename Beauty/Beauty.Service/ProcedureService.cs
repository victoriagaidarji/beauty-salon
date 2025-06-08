using AutoMapper;
using Beauty.Data;
using Beauty.Service.Interface;
using Beauty.Service.ModelsRequest;

namespace Beauty.Service
{
    public class ProcedureService : BaseService<Procedure, ProcedureRequest, IProcedureProvider>, IProcedureService
    {
        private readonly IProcedureProvider _provider;
        private readonly IMapper _mapper;

        public ProcedureService(IProcedureProvider provider, IMapper mapper) : base(provider, mapper)
        {
            _provider = provider;
            _mapper = mapper;
        }

        public async Task<List<Procedure>> GetProceduresByCategory(string category, CancellationToken cancellationToken)
        {
            return await _provider.GetByCategoryAsync(category, cancellationToken);
        }

        public async Task<List<Procedure>> GetProceduresByName(string name, CancellationToken cancellationToken)
        {
            return await _provider.GetByNameAsync(name, cancellationToken);
        }
    }
}