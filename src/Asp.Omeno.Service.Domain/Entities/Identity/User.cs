using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Asp.Omeno.Service.Domain.Entities.Identity
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long Tokens { get; set; }
        public string StripeCustomerId { get; set; }
        public bool AcceptedTerms { get; set; }
        public Guid LanguageId { get; set; }
        public bool Status { get; set; } = true;
        public bool IsDeleted { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual Language Language { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }
        public virtual ICollection<AutoBid> AutoBids { get; set; }
        public virtual ICollection<NotificationUser> NotificationUsers { get; set; }
    }
}
