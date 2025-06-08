using Beauty.Data;
using Beauty.Service.Interface;
using ClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Infrastructure.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly ApplicationContext _context;

        public UserProvider(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddAsync(User entity, CancellationToken cancellationToken)
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var user = await FindAsync(id, cancellationToken);
            ArgumentNullException.ThrowIfNull(user);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<User?> FindAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Users
                .Include(u => u.Appointments)
                .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        }

        public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Users
                .Include(u => u.Appointments)
                .ToListAsync(cancellationToken);
        }

        public async Task<User> UpdateAsync(User entity, CancellationToken cancellationToken)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username, cancellationToken);
        }

        public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        }
    }
}
