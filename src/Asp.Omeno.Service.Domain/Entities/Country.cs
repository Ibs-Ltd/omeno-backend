using Asp.Omeno.Service.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Domain.Entities
{
    public class Country : Entity<Guid>
    {
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public int VAT { get; set; }
        public Guid CurrencyId { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
