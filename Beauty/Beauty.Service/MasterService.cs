using AutoMapper;
using Beauty.Data;
using Beauty.Service.Interface;
using Beauty.Service.ModelsRequest;

namespace Beauty.Service
{
    public class MasterService : BaseService<Master, MasterRequest, IMasterProvider>, IMasterService
    {
        private readonly IMasterProvider _provider;
        private readonly IMapper _mapper;

        public MasterService(IMasterProvider provider, IMapper mapper) : base(provider, mapper)
        {
            _provider = provider;
            _mapper = mapper;
        }

        public async Task<List<Master>> GetMastersBySpecialization(string specialization, CancellationToken cancellationToken)
        {
            var allMasters = await _provider.GetAllAsync(cancellationToken);
            return allMasters.Where(m => m.Specialization.Equals(specialization, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}