using Asp.Omeno.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Asp.Omeno.Service.Persistence.Configurations
{
    public class ProductStatusConfiguration : IEntityTypeConfiguration<ProductStatus>
    {
        public void Configure(EntityTypeBuilder<ProductStatus> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("ID")
               .IsRequired();

            builder.Property(x => x.Name)
               .HasColumnName("Name")
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

            Constrains(builder);

            builder.ToTable("ProductStatuses");
        }

        private void Constrains(EntityTypeBuilder<ProductStatus> builder)
        {
            builder.HasQueryFilter(p => p.Status);
        }
    }
}
