using Asp.Omeno.Service.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Domain.Entities
{
    public class City : Entity<Guid>
    {
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ZipCode { get; set; }
        public Guid CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
