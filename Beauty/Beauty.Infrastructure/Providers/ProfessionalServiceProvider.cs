using Beauty.Data;
using Beauty.Service.Interface;
using ClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Infrastructure.Providers;

public class ProfessionalServiceProvider : IProfessionalServiceProvider
{
    private readonly ApplicationContext _context;

    public ProfessionalServiceProvider(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Guid> AddAsync(ProfessionalService entity, CancellationToken cancellationToken)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<ProfessionalService?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.ProfessionalServices.FindAsync(new object?[] { id }, cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await FindAsync(id, cancellationToken);
        ArgumentNullException.ThrowIfNull(entity);
        _context.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<ProfessionalService> UpdateAsync(ProfessionalService entity, CancellationToken cancellationToken)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<List<ProfessionalService>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.ProfessionalServices.ToListAsync(cancellationToken);
    }
}