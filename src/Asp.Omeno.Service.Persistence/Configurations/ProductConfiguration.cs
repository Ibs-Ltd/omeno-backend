using Asp.Omeno.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asp.Omeno.Service.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("ID")
               .IsRequired();

            builder.Property(x => x.Name)
               .HasColumnName("Name")
               .IsRequired();

            builder.Property(x => x.NormalizedName)
               .HasColumnName("NormalizedName")
               .IsRequired();

            builder.Property(x => x.Description)
               .HasColumnName("Description")
               .IsRequired();

            builder.Property(x => x.Price)
               .HasColumnName("Price")
               .IsRequired();

            builder.Property(x => x.StartTime)
              .HasColumnName("StartTime")
              .IsRequired();

            builder.Property(x => x.EndTime)
               .HasColumnName("EndTime")
               .IsRequired();

            builder.Property(x => x.Active)
               .HasColumnName("Active")
               .IsRequired();

            builder.Property(x => x.Index)
               .HasColumnName("Index")
               .IsRequired();
            
            builder.Property(x => x.Counter)
               .HasColumnName("Counter")
               .IsRequired();

            builder.Property(x => x.ProductStatusId)
                .HasColumnName("ProductStatus_ID")
                .IsRequired();

            builder.Property(x => x.ProductTypeId)
                .HasColumnName("ProductType_ID")
                .IsRequired();

            builder.Property(x => x.ProductStepId)
               .HasColumnName("ProductStep_ID")
               .IsRequired();

            builder.Property(x => x.FirstImageId)
                .HasColumnName("FirstImage_ID")
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .IsRequired();

            Relationships(builder);
            Constrains(builder);

            builder.ToTable("Products");
        }

        private void Relationships(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(x => x.ProductStatus)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.ProductStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ProductType)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.ProductTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ProductStep)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.ProductStepId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Image)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.FirstImageId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void Constrains(EntityTypeBuilder<Product> builder)
        {
            builder.HasQueryFilter(p => p.Status);
        }
    }
}
