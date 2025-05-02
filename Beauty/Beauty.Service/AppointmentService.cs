using AutoMapper;
using Beauty.Data;
using Beauty.Service.Interface;
using Beauty.Service.ModelsRequest;

namespace Beauty.Service;

public class AppointmentService : BaseService<Appointment, AppointmentRequest, IAppointmentProvider>, IAppointmentService
{
    private IAppointmentProvider _provider;
    private IMapper _mapper;

    public AppointmentService(IAppointmentProvider provider, IMapper mapper) : base(provider, mapper)
    {
        _provider = provider;
        _mapper = mapper;
    }

    public Task<List<Appointment>> GetByUserId(Guid userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
