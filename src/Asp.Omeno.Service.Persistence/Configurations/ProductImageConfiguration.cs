using Asp.Omeno.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asp.Omeno.Service.Persistence.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.ImageId});

            builder.Property(x => x.Id)
               .HasColumnName("ID")
               .IsRequired();

            builder.Property(x => x.ProductId)
               .HasColumnName("Product_ID")
               .IsRequired();
            
            builder.Property(x => x.ImageId)
               .HasColumnName("Image_ID")
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

            builder.ToTable("ProductImages");
        }

        private void Relationships(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductImages)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(x => x.Image)
                .WithMany(x => x.ProductImages)
                .HasForeignKey(x => x.ImageId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void Constrains(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasQueryFilter(p => p.Status);
        }
    }
}
