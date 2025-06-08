using Beauty.Data;
using Beauty.Service.Interface;
using ClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Infrastructure.Providers
{
    public class AppointmentProvider : IAppointmentProvider
    {
        private readonly ApplicationContext _context;

        public AppointmentProvider(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddAsync(Appointment entity, CancellationToken cancellationToken)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<Appointment?> FindAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Appointments
                .Include(a => a.User)
                .Include(a => a.Master)
                .Include(a => a.Procedure)
                .Include(a => a.Payment)
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var appointment = await FindAsync(id, cancellationToken);
            ArgumentNullException.ThrowIfNull(appointment);
            _context.Remove(appointment);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Appointment> UpdateAsync(Appointment entity, CancellationToken cancellationToken)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<List<Appointment>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Appointments
                .Include(a => a.User)
                .Include(a => a.Master)
                .Include(a => a.Procedure)
                .Include(a => a.Payment)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Appointment>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _context.Appointments
                .Where(a => a.UserId == userId)
                .Include(a => a.Master)
                .Include(a => a.Procedure)
                .Include(a => a.Payment)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Appointment>> GetByMasterIdAsync(Guid masterId, CancellationToken cancellationToken)
        {
            return await _context.Appointments
                .Where(a => a.MasterId == masterId)
                .Include(a => a.User)
                .Include(a => a.Procedure)
                .Include(a => a.Payment)
                .ToListAsync(cancellationToken);
        }
    }
}
