using Asp.Omeno.Service.Domain.Entities.Base;
using System;

namespace Asp.Omeno.Service.Domain.Entities
{
    public class DefaultTime : Entity<Guid>
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
