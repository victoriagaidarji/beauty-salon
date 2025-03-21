using Microsoft.EntityFrameworkCore;
using Photo.Data;
using Photo.Service.Interface;

namespace ClassLibrary.Providers;

public class PictureProvider:IPictureProvider

{
    private readonly ApplicationContext _applicationContext;

    public PictureProvider(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }
    public async Task<Guid> AddAsync(global::Photo.Data.Picture entity, CancellationToken cancellationToken)
    {
        // if (await _applicationContext.Employees.ContainsAsync(entity.Boss, cancellationToken))
        //     _applicationContext.Entry(entity.Boss).State = EntityState.Unchanged;
        _applicationContext.Add(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return entity.Id;
    }

    public async Task<global::Photo.Data.Picture?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _applicationContext.Pictures
            .Include(c => c.Registration)
            .FirstOrDefaultAsync(d => d.Id == id, cancellationToken).ConfigureAwait(false);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var division = await FindAsync(id, cancellationToken);
        ArgumentNullException.ThrowIfNull(division);
        _applicationContext.Remove(division);
        await _applicationContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<global::Photo.Data.Picture> UpdateAsync(global::Photo.Data.Picture entity, CancellationToken cancellationToken)
    {
        _applicationContext.Update(entity);
        await _applicationContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<List<global::Photo.Data.Picture>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _applicationContext.Pictures
            .Include(c => c.Registration)
            .ToListAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task<List<Picture>> GetAllAsyncByRegistration(Registration registration, CancellationToken cancellationToken)
    {
        return  _applicationContext.Pictures
            .Include(p => p.Registration)
            .ToList();
    }
}