using CondoApi.Domain.Entities;

namespace CondoApi.Domain.Interfaces;

public interface IPersonRepository : IGenericRepository<Person>
{
    Task<Person> GetPersonByEmailAsync(string email);
}
