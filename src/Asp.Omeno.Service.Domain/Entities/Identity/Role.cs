using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Domain.Entities.Identity
{
    public class Role : IdentityRole<Guid>
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
