using Beauty.Data;
using Beauty.Service.Interface;
using ClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Infrastructure.Providers
{
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
            return await _context.Payments
                .Include(p => p.Appointment)
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var payment = await FindAsync(id, cancellationToken);
            ArgumentNullException.ThrowIfNull(payment);
            _context.Remove(payment);
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
            return await _context.Payments
                .Include(p => p.Appointment)
                .ToListAsync(cancellationToken);
        }

        public async Task<Payment?> GetByAppointmentIdAsync(Guid appointmentId, CancellationToken cancellationToken)
        {
            return await _context.Payments
                .Include(p => p.Appointment)
                .FirstOrDefaultAsync(p => p.AppointmentId == appointmentId, cancellationToken);
        }
    }
}
