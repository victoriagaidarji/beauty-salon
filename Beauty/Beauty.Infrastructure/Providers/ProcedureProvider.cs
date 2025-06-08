using Beauty.Data;
using Beauty.Service.Interface;
using ClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Infrastructure.Providers
{
    public class ProcedureProvider : IProcedureProvider
    {
        private readonly ApplicationContext _context;

        public ProcedureProvider(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddAsync(Procedure entity, CancellationToken cancellationToken)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<Procedure?> FindAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Procedures
                .Include(p => p.MasterServices)
                .Include(p => p.Appointments)
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var procedure = await FindAsync(id, cancellationToken);
            ArgumentNullException.ThrowIfNull(procedure);
            _context.Remove(procedure);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Procedure> UpdateAsync(Procedure entity, CancellationToken cancellationToken)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<List<Procedure>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Procedures
                .Include(p => p.MasterServices)
                .Include(p => p.Appointments)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Procedure>> GetByCategoryAsync(string category, CancellationToken cancellationToken)
        {
            return await _context.Procedures
                .Where(p => p.Category == category)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<Procedure>> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _context.Procedures
                .Where(p => p.Name == name)
                .ToListAsync(cancellationToken);
        }
    }
}
