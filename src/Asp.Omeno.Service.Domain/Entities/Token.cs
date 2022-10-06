using Asp.Omeno.Service.Domain.Entities.Base;
using System;

namespace Asp.Omeno.Service.Domain.Entities
{
    public class Token : Entity<Guid>
    {
        public string Key { get; set; }
        public double Value { get; set; }
    }
}
