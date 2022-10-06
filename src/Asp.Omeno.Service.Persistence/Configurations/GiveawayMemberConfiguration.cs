using Asp.Omeno.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asp.Omeno.Service.Persistence.Configurations
{
    public class GiveawayMemberConfiguration : IEntityTypeConfiguration<GiveawayMember>
    {
        public void Configure(EntityTypeBuilder<GiveawayMember> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("ID")
               .IsRequired();

            builder.Property(x => x.ProductId)
               .HasColumnName("Product_ID")
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

            builder.ToTable("GiveawayMembers");
        }

        private void Relationships(EntityTypeBuilder<GiveawayMember> builder)
        {
            builder.HasOne(x => x.Product)
                .WithMany(x => x.GiveawayMembers)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void Constrains(EntityTypeBuilder<GiveawayMember> builder)
        {
            builder.HasQueryFilter(p => p.Status);
        }
    }
}
