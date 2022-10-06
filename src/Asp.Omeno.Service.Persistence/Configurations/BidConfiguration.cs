using Asp.Omeno.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asp.Omeno.Service.Persistence.Configurations
{
    public class BidConfiguration : IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("ID")
               .IsRequired();

            builder.Property(x => x.TimeOfBid)
               .HasColumnName("TimeOfBid")
               .IsRequired();

            builder.Property(x => x.IsLast)
               .HasColumnName("IsLast")
               .IsRequired();

            builder.Property(x => x.IsAutoBid)
               .HasColumnName("IsAutoBid")
               .IsRequired();

            builder.Property(x => x.ProductId)
               .HasColumnName("Product_ID")
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

            builder.ToTable("Bids");
        }

        private void Relationships(EntityTypeBuilder<Bid> builder)
        {
            builder.HasOne(x => x.Product)
                .WithMany(x => x.Bids)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Bids)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void Constrains(EntityTypeBuilder<Bid> builder)
        {
            builder.HasQueryFilter(p => p.Status);
        }
    }
}
