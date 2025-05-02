using Beauty.Data;
using Beauty.Service.Interface;
using ClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Infrastructure.Providers;

public class PaymentProvider : IPaymentProvider
{
    private readonly ApplicationContext _context;

    public PaymentProvider(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Guid> AddAsync(Payment entity, CancellationToken cancellationToken)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<Payment?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Payments.FindAsync(new object?[] { id }, cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await FindAsync(id, cancellationToken);
        ArgumentNullException.ThrowIfNull(entity);
        _context.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Payment> UpdateAsync(Payment entity, CancellationToken cancellationToken)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<List<Payment>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Payments.ToListAsync(cancellationToken);
    }
}
