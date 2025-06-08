using AutoMapper;
using Beauty.Data;
using Beauty.Service.Interface;
using Beauty.Service.ModelsRequest;

namespace Beauty.Service
{
    public class AppointmentService : BaseService<Appointment, AppointmentRequest, IAppointmentProvider>, IAppointmentService
    {
        private readonly IAppointmentProvider _provider;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentProvider provider, IMapper mapper) : base(provider, mapper)
        {
            _provider = provider;
            _mapper = mapper;
        }

        public async Task<List<Appointment>> GetAppointmentsByUser(Guid userId, CancellationToken cancellationToken)
        {
            return await _provider.GetByUserIdAsync(userId, cancellationToken);
        }

        public async Task<List<Appointment>> GetAppointmentsByMaster(Guid masterId, CancellationToken cancellationToken)
        {
            return await _provider.GetByMasterIdAsync(masterId, cancellationToken);
        }
    }
}