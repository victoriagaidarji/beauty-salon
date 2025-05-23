using Beauty.Data;
using Beauty.Service.ModelsRequest;

namespace Beauty.Service.Interface
{
    public interface IAppointmentService : IBaseService<Appointment, AppointmentRequest>
    {
        Task<List<Appointment>> GetByUserId(Guid userId, CancellationToken cancellationToken);
        Task<object?> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}