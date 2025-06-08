using Beauty.Data;
using Beauty.Service.ModelsRequest;

namespace Beauty.Service.Interface
{
    public interface IAppointmentService : IBaseService<Appointment, AppointmentRequest>
    {
        Task<List<Appointment>> GetAppointmentsByUser(Guid userId, CancellationToken cancellationToken);
        Task<List<Appointment>> GetAppointmentsByMaster(Guid masterId, CancellationToken cancellationToken);
    }
}