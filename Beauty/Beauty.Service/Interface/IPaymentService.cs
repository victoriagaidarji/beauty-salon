using Beauty.Data;
using Beauty.Service.ModelsRequest;

namespace Beauty.Service.Interface
{
    public interface IPaymentService : IBaseService<Payment, PaymentRequest>
    {
        Task<Payment?> GetPaymentByAppointmentId(Guid appointmentId, CancellationToken cancellationToken);
    }
}