using Microsoft.EntityFrameworkCore;
using Photo.Data;
using Photo.Service.Interface;

namespace ClassLibrary.Providers;

public class PortfolioProvider:IPortfolioProvider
{
    private readonly ApplicationContext _applicationContext;

    public PortfolioProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }
    public async Task<Guid> AddAsync(Portfolio entity, CancellationToken cancellationToken)
    {
        // if (await _applicationContext.Employees.ContainsAsync(entity.Boss, cancellationToken))
        //     _applicationContext.Entry(entity.Boss).State = EntityState.Unchanged;
        _applicationContext.Add(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return entity.Id;
    }

    public async Task<Portfolio?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _applicationContext.Portfolios
            .Include(p=> p.Id)
            .FirstOrDefaultAsync(d => d.Id == id, cancellationToken).ConfigureAwait(false);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var division = await FindAsync(id, cancellationToken);
        ArgumentNullException.ThrowIfNull(division);
        _applicationContext.Remove(division);
        await _applicationContext.SaveChangesAsync(cancellationToken);;
    }

    public async Task<Portfolio> UpdateAsync(Portfolio entity, CancellationToken cancellationToken)
    {
        _applicationContext.Update(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<List<Portfolio>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _applicationContext.Portfolios
            .Include(p => p.PhotoType)
            .ToListAsync(cancellationToken);
    }
}