using Asp.Omeno.Service.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Domain.Entities
{
    public class ProductType : Entity<Guid>
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
