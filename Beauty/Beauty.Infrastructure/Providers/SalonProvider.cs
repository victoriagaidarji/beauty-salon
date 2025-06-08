using Beauty.Data;
using Beauty.Service.Interface;
using ClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Infrastructure.Providers
{
    public class SalonProvider : ISalonProvider
    {
        private readonly ApplicationContext _context;

        public SalonProvider(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddAsync(Salon entity, CancellationToken cancellationToken)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var salon = await FindAsync(id, cancellationToken);
            ArgumentNullException.ThrowIfNull(salon);
            _context.Remove(salon);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Salon?> FindAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Salons.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        public async Task<List<Salon>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Salons.ToListAsync(cancellationToken);
        }

        public async Task<Salon> UpdateAsync(Salon entity, CancellationToken cancellationToken)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<List<Salon>> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _context.Salons
                .Where(s => s.Name == name)
                .ToListAsync(cancellationToken);
        }
    }
}