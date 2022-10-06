using Asp.Omeno.Service.Domain.Entities.Base;
using System;

namespace Asp.Omeno.Service.Domain.Entities
{
    public class ProductImage : Entity<Guid>
    {
        public Guid ProductId { get; set; }
        public Guid ImageId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Image Image { get; set; }
    }
}
