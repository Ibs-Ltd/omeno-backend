using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Domain.Entities;
using Asp.Omeno.Service.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Asp.Omeno.Service.Persistence
{
    public class ServiceDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IServiceDbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<AutoBid> AutoBids { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<DefaultTime> DefaultTimes { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<GiveawayMember> GiveawayMembers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceStatus> InvoiceStatuses { get; set; }
        public DbSet<InvoiceType> InvoiceTypes { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationType> NotificationTypes { get; set; }
        public DbSet<NotificationUser> NotificationUsers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductStatus> ProductStatuses { get; set; }
        public DbSet<ProductStep> ProductSteps { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Token> Tokens { get; set; }

        public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var table = entityType.GetTableName();
                if (table.StartsWith("AspNet"))
                    entityType.SetTableName(table.Substring(6));
            }

            builder.ApplyConfigurationsFromAssembly(typeof(ServiceDbContext).Assembly);
        }
    }
}
