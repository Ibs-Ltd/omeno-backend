using Asp.Omeno.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Asp.Omeno.Service.Persistence.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("ID")
               .IsRequired();

            builder.Property(x => x.Quantity)
               .HasColumnName("Quantity")
               .IsRequired();

            builder.Property(x => x.InvoiceStatusId)
               .HasColumnName("InvoiceStatus_ID")
               .IsRequired();

            builder.Property(x => x.InvoiceTypeId)
               .HasColumnName("InvoiceType_ID")
               .IsRequired();

            builder.Property(x => x.UserId)
               .HasColumnName("User_ID")
               .IsRequired();

            builder.Property(x => x.ProductId)
               .HasColumnName("Product_ID")
               .IsRequired(false);

            builder.Property(x => x.Status)
                 .HasColumnName("Status")
                 .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .IsRequired();

            Relationships(builder);
            Constrains(builder);

            builder.ToTable("Invoices");
        }

        private void Relationships(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasOne(x => x.InvoiceStatus)
                .WithMany(x => x.Invoices)
                .HasForeignKey(x => x.InvoiceStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.InvoiceType)
                .WithMany(x => x.Invoices)
                .HasForeignKey(x => x.InvoiceTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Invoices)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Product)
              .WithMany(x => x.Invoices)
              .HasForeignKey(x => x.ProductId)
              .OnDelete(DeleteBehavior.Restrict);
        }

        private void Constrains(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasQueryFilter(p => p.Status);
        }
    }
}
