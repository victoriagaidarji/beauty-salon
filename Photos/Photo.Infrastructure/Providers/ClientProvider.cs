using Microsoft.EntityFrameworkCore;
using Photo.Data;
using Photo.Service.Interface;

namespace ClassLibrary.Providers;

public class ClientProvider : IClientProvider
{
    private readonly ApplicationContext _applicationContext;

    public ClientProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }
    public async Task<Guid> AddAsync(Client entity, CancellationToken cancellationToken)
    {
        // if (await _applicationContext.Employees.ContainsAsync(entity.Boss, cancellationToken))
        //     _applicationContext.Entry(entity.Boss).State = EntityState.Unchanged;
        _applicationContext.Add(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return entity.Id;
    }

    public async Task<Client?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _applicationContext.Clients
            .Include(c => c.Registrations)
            .FirstOrDefaultAsync(d => d.Id == id, cancellationToken).ConfigureAwait(false);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var division = await FindAsync(id, cancellationToken);
        ArgumentNullException.ThrowIfNull(division);
        _applicationContext.Remove(division);
        await _applicationContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Client> UpdateAsync(Client entity, CancellationToken cancellationToken)
    {
        _applicationContext.Update(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<List<Client>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _applicationContext.Clients
            .Include(c => c.Registrations)
            .ToListAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task<Client?> FindAsync(string phone, CancellationToken cancellationToken)
    {
        return await _applicationContext.Clients
            .Include(c => c.Registrations)
            .FirstOrDefaultAsync(c => c.Phone == phone, cancellationToken).ConfigureAwait(false);
    }
}