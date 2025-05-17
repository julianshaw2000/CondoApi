namespace CondoApi.Domain.Interfaces;


public interface IUnitOfWork
{
    IUserRepository Users { get; }
    IApartmentRepository Apartments { get; }
    IPersonRepository Persons { get; }
    Task<int> CompleteAsync(); // Save changes
}
