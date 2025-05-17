using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoApi.Domain.Entities;

public class Apartment
{
    public int Id { get; set; }
    public string UnitNumber { get; set; } = string.Empty;
    public int OwnerId { get; set; }
    public User Owner { get; set; } = null!;
    public List<Person> Persons { get; set; } = new();
}
