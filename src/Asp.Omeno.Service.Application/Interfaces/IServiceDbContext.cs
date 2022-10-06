using Asp.Omeno.Service.Domain.Entities;
using Asp.Omeno.Service.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Interfaces
{
    public interface IServiceDbContext
    {
        DbSet<Address> Addresses { get; set; }
        DbSet<AddressType> AddressTypes { get; set; }
        DbSet<AutoBid> AutoBids { get; set; }
        DbSet<Bid> Bids { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Currency> Currencies { get; set; }
        DbSet<DefaultTime> DefaultTimes { get; set; }
        DbSet<EmailTemplate> EmailTemplates { get; set; }
        DbSet<GiveawayMember> GiveawayMembers { get; set; }
        DbSet<Invoice> Invoices { get; set; }
        DbSet<InvoiceStatus> InvoiceStatuses { get; set; }
        DbSet<InvoiceType> InvoiceTypes { get; set; }
        DbSet<Language> Languages { get; set; }
        DbSet<Notification> Notifications { get; set; }
        DbSet<NotificationType> NotificationTypes { get; set; }
        DbSet<NotificationUser> NotificationUsers { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductImage> ProductImages { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<ProductStatus> ProductStatuses { get; set; }
        DbSet<ProductType> ProductTypes { get; set; }
        DbSet<ProductStep> ProductSteps { get; set; }
        DbSet<Token> Tokens { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserRole> UserRoles { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
