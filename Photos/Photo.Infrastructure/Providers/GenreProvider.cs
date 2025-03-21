using Microsoft.EntityFrameworkCore;
using Photo.Data;
using Photo.Service.Interface;

namespace ClassLibrary.Providers;

public class GenreProvider : IGenreProvider
{
    private readonly ApplicationContext _applicationContext;

    public GenreProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }
    public async Task<Guid> AddAsync(Genre entity, CancellationToken cancellationToken)
    {
        // if (await _applicationContext.Employees.ContainsAsync(entity.Boss, cancellationToken))
        //     _applicationContext.Entry(entity.Boss).State = EntityState.Unchanged;
        _applicationContext.Add(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return entity.Id;
    }

    public async Task<Genre?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _applicationContext.Genres
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

    public async Task<Genre> UpdateAsync(Genre entity, CancellationToken cancellationToken)
    {
        _applicationContext.Update(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<List<Genre>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _applicationContext.Genres
            .Include(c => c.Registrations)
            .ToListAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task<Genre?> FindAsync(string name, CancellationToken cancellationToken)
    {
        return await _applicationContext.Genres
            .Include(c => c.Registrations)
            .FirstOrDefaultAsync(n => n.Name == name, cancellationToken).ConfigureAwait(false);
    }
}