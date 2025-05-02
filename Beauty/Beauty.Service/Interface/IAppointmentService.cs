using Beauty.Data;
using Beauty.Service.ModelsRequest;

namespace Beauty.Service.Interface
{
    public interface IAppointmentService : IBaseService<Appointment, AppointmentRequest>
    {
        Task<List<Appointment>> GetByUserId(Guid userId, CancellationToken cancellationToken);
    }
}