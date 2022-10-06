using Asp.Omeno.Service.Domain.Entities.Base;
using Asp.Omeno.Service.Domain.Entities.Identity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Domain.Entities
{
    public class Language : Entity<Guid>
    {
        public string Name { get; set; }
        public string NormalizedName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
