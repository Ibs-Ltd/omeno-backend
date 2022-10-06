using Asp.Omeno.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Asp.Omeno.Service.Persistence.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("ID")
               .IsRequired();

            builder.Property(x => x.CardNumber)
               .HasColumnName("CardNumber")
               .IsRequired();

            builder.Property(x => x.CardHolder)
               .HasColumnName("CardHolder")
               .IsRequired();

            builder.Property(x => x.Month)
               .HasColumnName("Month")
               .IsRequired();

            builder.Property(x => x.Year)
              .HasColumnName("Year")
              .IsRequired();

            builder.Property(x => x.UserId)
               .HasColumnName("User_ID")
               .IsRequired();

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

            builder.ToTable("Payments");
        }

        private void Relationships(EntityTypeBuilder<Payment> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void Constrains(EntityTypeBuilder<Payment> builder)
        {
            builder.HasQueryFilter(p => p.Status);
        }
    }
}
