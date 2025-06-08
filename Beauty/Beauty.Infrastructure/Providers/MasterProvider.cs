using ClassLibrary;
using Beauty.Data;
using Beauty.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Infrastructure.Providers
{
    public class MasterProvider : IMasterProvider
    {
        private readonly ApplicationContext _context;

        public MasterProvider(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddAsync(Master entity, CancellationToken cancellationToken)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<Master?> FindAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Masters
                .Include(m => m.MasterServices)
                .Include(m => m.Appointments)
                .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var master = await FindAsync(id, cancellationToken);
            ArgumentNullException.ThrowIfNull(master);
            _context.Remove(master);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Master> UpdateAsync(Master entity, CancellationToken cancellationToken)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<List<Master>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Masters
                .Include(m => m.MasterServices)
                .Include(m => m.Appointments)
                .ToListAsync(cancellationToken);
        }
    }
}
