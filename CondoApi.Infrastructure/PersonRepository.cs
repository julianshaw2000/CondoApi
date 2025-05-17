
using CondoApi.Domain.Entities;
using CondoApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace CondoApi.Infrastructure;

public class PersonRepository : GenericRepository<Person>, IPersonRepository
{
    public PersonRepository(AppDbContext context) : base(context) { }

    public Task<Person> GetPersonByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    // public async Task<Person?> GetPersonByEmailAsync(string email)
    // {
    //     return await _context.Persons.FirstOrDefaultAsync(u => u.Email == email);
    // }
}
