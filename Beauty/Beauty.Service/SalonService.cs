using AutoMapper;
using Beauty.Data;
using Beauty.Service.Interface;
using Beauty.Service.ModelsRequest;

namespace Beauty.Service
{
    public class SalonService : BaseService<Salon, SalonRequest, ISalonProvider>, ISalonService
    {
        private readonly ISalonProvider _provider;
        private readonly IMapper _mapper;

        public SalonService(ISalonProvider provider, IMapper mapper) : base(provider, mapper)
        {
            _provider = provider;
            _mapper = mapper;
        }

        public async Task<List<Salon>> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _provider.GetByNameAsync(name, cancellationToken);
        }
    }
}