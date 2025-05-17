using CondoApi.Domain.Entities;
using CondoApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace CondoApi.Infrastructure;

public class ApartmentRepository : GenericRepository<Apartment>, IApartmentRepository
{
    public ApartmentRepository(AppDbContext context) : base(context) { }

    // public   Task<Apartment?> GetApartmentByNumberAsync(string number)
    // {
    //     // return await _context.Apartments.FirstOrDefaultAsync(a => a.Number == number);
    // }
}
