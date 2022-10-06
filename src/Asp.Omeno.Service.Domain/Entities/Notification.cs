using Asp.Omeno.Service.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Domain.Entities
{
    public class Notification : Entity<Guid>
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public bool AutoNotify { get; set; }
        public bool Active { get; set; }
        public bool Timer { get; set; }
        public DateTime TimeToNotify { get; set; }
        public Guid NotificationTypeId { get; set; }

        public virtual NotificationType NotificationType { get; set; }
        public virtual ICollection<NotificationUser> NotificationUsers { get; set; }
    }
}
