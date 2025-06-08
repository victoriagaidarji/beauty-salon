using AutoMapper;
using Beauty.Data;
using Beauty.Service.Interface;
using Beauty.Service.ModelsRequest;

namespace Beauty.Service
{
    public class PaymentService : BaseService<Payment, PaymentRequest, IPaymentProvider>, IPaymentService
    {
        private readonly IPaymentProvider _provider;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentProvider provider, IMapper mapper) : base(provider, mapper)
        {
            _provider = provider;
            _mapper = mapper;
        }

        public async Task<Payment?> GetPaymentByAppointmentId(Guid appointmentId, CancellationToken cancellationToken)
        {
            return await _provider.GetByAppointmentIdAsync(appointmentId, cancellationToken);
        }
    }
}