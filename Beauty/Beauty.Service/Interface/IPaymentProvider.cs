using Beauty.Data;

namespace Beauty.Service.Interface
{
    public interface IPaymentProvider : IBaseProvider<Payment>
    {
        Task<Payment?> GetByAppointmentIdAsync(Guid appointmentId, CancellationToken cancellationToken);
    }
}