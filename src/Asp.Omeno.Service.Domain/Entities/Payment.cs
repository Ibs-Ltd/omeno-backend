using Asp.Omeno.Service.Domain.Entities.Base;
using Asp.Omeno.Service.Domain.Entities.Identity;
using System;

namespace Asp.Omeno.Service.Domain.Entities
{
    public class Payment : Entity<Guid>
    {
        public string CardNumber { get; set; }
        public string CardHolder { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}
