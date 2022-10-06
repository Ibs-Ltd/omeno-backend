using Asp.Omeno.Service.Domain.Entities.Base;
using System;

namespace Asp.Omeno.Service.Domain.Entities
{
    public class EmailTemplate : Entity<Guid>
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
