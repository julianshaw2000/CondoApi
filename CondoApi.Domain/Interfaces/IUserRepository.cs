using CondoApi.Domain.Entities;

namespace CondoApi.Domain.Interfaces;


public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetUserByEmailAsync(string email);
}
