using CondoApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoApi.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public PersonType PersonType { get; set; }
        public int ApartmentId { get; set; }
        //public Apartment Apartment { get; set; } = null!;
    }
}
