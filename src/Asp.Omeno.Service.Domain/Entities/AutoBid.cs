using Asp.Omeno.Service.Domain.Entities.Base;
using Asp.Omeno.Service.Domain.Entities.Identity;
using System;

namespace Asp.Omeno.Service.Domain.Entities
{
    public class AutoBid : Entity<Guid>
    {
        public bool Active { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public double MaxPrice { get; set; }

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
