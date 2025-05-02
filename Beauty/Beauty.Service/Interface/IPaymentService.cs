using Beauty.Data;
using Beauty.Service.ModelsRequest;

namespace Beauty.Service.Interface
{
    public interface IPaymentService : IBaseService<Payment, PaymentRequest>
    {
        Task<List<Payment>> GetPendingPayments(CancellationToken cancellationToken);
    }
}