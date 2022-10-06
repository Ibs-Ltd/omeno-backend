using Asp.Omeno.Service.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Domain.Entities
{
    public class Product : Entity<Guid>
    {
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Active { get; set; }
        public int Index { get; set; }
        public int Counter { get; set; }
        public Guid ProductTypeId { get; set; }
        public Guid ProductStatusId { get; set; }
        public Guid ProductStepId { get; set; }
        public Guid FirstImageId { get; set; }
        public double PriceStart { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }
        public virtual ICollection<AutoBid> AutoBids { get; set; }
        public virtual ICollection<GiveawayMember> GiveawayMembers { get; set; }
        public virtual ProductStatus ProductStatus { get; set; }
        public virtual ProductType ProductType { get; set; }
        public virtual ProductStep ProductStep { get; set; }
        public virtual Image Image { get; set; }
    }
}
