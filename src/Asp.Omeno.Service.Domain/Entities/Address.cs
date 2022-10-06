using Asp.Omeno.Service.Domain.Entities.Base;
using Asp.Omeno.Service.Domain.Entities.Identity;
using System;

namespace Asp.Omeno.Service.Domain.Entities
{
    public class Address : Entity<Guid>
    {
        public string AddressName { get; set; }
        public string AddressNameTwo { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public string PostalCode { get; set; }
        public Guid UserId { get; set; }
        public Guid? CityId { get; set; }
        public Guid AddressTypeId { get; set; }

        public virtual User User { get; set; }
        public virtual City City { get; set; }
        public virtual AddressType AddressType { get; set; }
    }
}
