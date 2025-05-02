using AutoMapper;
using Beauty.Data;
using Beauty.Service.Interface;
using Beauty.Service.ModelsRequest;

namespace Beauty.Service;

public class PaymentService : BaseService<Payment, PaymentRequest, IPaymentProvider>, IPaymentService
{
    private IPaymentProvider _provider;
    private IMapper _mapper;

    public PaymentService(IPaymentProvider provider, IMapper mapper) : base(provider, mapper)
    {
        _provider = provider;
        _mapper = mapper;
    }

    public Task<List<Payment>> GetPendingPayments(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
