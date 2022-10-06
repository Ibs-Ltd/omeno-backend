using Asp.Omeno.Service.Domain.Entities.Base;
using Asp.Omeno.Service.Domain.Entities.Identity;
using System;

namespace Asp.Omeno.Service.Domain.Entities
{
    public class NotificationUser : Entity<Guid>
    {
        public Guid NotificationId { get; set; }
        public Guid UserId { get; set; }

        public virtual Notification Notification { get; set; }
        public virtual User User { get; set; }
    }
}
