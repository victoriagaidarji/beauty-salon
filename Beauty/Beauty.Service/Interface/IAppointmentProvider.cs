using Beauty.Data;

namespace Beauty.Service.Interface
{
    public interface IAppointmentProvider : IBaseProvider<Appointment>
    {
        Task<List<Appointment>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
        Task<List<Appointment>> GetByMasterIdAsync(Guid masterId, CancellationToken cancellationToken);
    }
}