using Asp.Omeno.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asp.Omeno.Service.Persistence.Configurations
{
    public class AutoBidConfiguration : IEntityTypeConfiguration<AutoBid>
    {
        public void Configure(EntityTypeBuilder<AutoBid> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("ID")
               .IsRequired();

            builder.Property(x => x.Active)
               .HasColumnName("Active")
               .IsRequired();

            builder.Property(x => x.ProductId)
               .HasColumnName("Product_ID")
               .IsRequired();

            builder.Property(x => x.UserId)
               .HasColumnName("User_ID")
               .IsRequired();

            builder.Property(x => x.MaxPrice)
                 .HasColumnName("MaxPrice")
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

            builder.ToTable("AutoBids");
        }

        private void Relationships(EntityTypeBuilder<AutoBid> builder)
        {
            builder.HasOne(x => x.Product)
                .WithMany(x => x.AutoBids)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.User)
                .WithMany(x => x.AutoBids)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void Constrains(EntityTypeBuilder<AutoBid> builder)
        {
            builder.HasQueryFilter(p => p.Status);
        }
    }
}
