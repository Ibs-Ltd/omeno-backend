using Asp.Omeno.Service.Domain.Entities.Base;
using Asp.Omeno.Service.Domain.Entities.Identity;
using System;

namespace Asp.Omeno.Service.Domain.Entities
{
    public class Invoice : Entity<Guid>
    {
        public int Quantity { get; set; }
        public Guid InvoiceStatusId { get; set; }
        public Guid InvoiceTypeId { get; set; }
        public Guid? ProductId { get; set; }
        public Guid UserId { get; set; }

        public virtual InvoiceStatus InvoiceStatus { get; set; }
        public virtual InvoiceType InvoiceType { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
