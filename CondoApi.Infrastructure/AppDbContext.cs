using CondoApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CondoApi.Infrastructure;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Person> Persons { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Apartment> Apartments { get; set; }
}


