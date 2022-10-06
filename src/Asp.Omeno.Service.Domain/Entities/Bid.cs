using Asp.Omeno.Service.Domain.Entities.Base;
using Asp.Omeno.Service.Domain.Entities.Identity;
using System;

namespace Asp.Omeno.Service.Domain.Entities
{
    public class Bid : Entity<Guid>
    {
        public DateTime TimeOfBid { get; set; }
        public bool IsLast { get; set; }
        public bool IsAutoBid { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
