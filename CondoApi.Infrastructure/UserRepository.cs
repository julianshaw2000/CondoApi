
using CondoApi.Domain.Entities;
using CondoApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace CondoApi.Infrastructure;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context) { }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}
