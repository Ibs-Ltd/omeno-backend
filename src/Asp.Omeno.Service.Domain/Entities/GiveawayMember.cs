using Asp.Omeno.Service.Domain.Entities.Base;
using System;

namespace Asp.Omeno.Service.Domain.Entities
{
    public class GiveawayMember : Entity<Guid>
    {
        public string Member { get; set; }
        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
