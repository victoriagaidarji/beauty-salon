using Beauty.Data;
using Beauty.Service.Interface;
using ClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Infrastructure.Providers;

public class UserProvider : IUserProvider
{
    private readonly ApplicationContext _context;

    public UserProvider(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Guid> AddAsync(User entity, CancellationToken cancellationToken)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public async Task<User?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Users.FindAsync(new object?[] { id }, cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await FindAsync(id, cancellationToken);
        ArgumentNullException.ThrowIfNull(entity);
        _context.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<User> UpdateAsync(User entity, CancellationToken cancellationToken)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Users.ToListAsync(cancellationToken);
    }
}