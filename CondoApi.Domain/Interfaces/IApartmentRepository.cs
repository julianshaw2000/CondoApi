using CondoApi.Domain.Entities;

namespace CondoApi.Domain.Interfaces;

public interface IApartmentRepository : IGenericRepository<Apartment>
{
    //  Task<Apartment> GetApartmentByNumberAsync(string number);
}
