using Asp.Omeno.Service.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Domain.Entities
{
    public class Currency : Entity<Guid>
    {
        public string Name { get; set; }
        public string NormalizedName { get; set; }        
       public double currencyRatio { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}
