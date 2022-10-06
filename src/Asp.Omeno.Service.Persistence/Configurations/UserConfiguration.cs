using Asp.Omeno.Service.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asp.Omeno.Service.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName)
                .HasColumnName("FirstName")
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnName("LastName")
                .IsRequired();
            
            builder.Property(x => x.DateOfBirth)
                .HasColumnName("DateOfBirth")
                .IsRequired();
            
            builder.Property(x => x.Tokens)
                .HasColumnName("Tokens")
                .IsRequired();

            builder.Property(x => x.StripeCustomerId)
                .HasColumnName("StripeCustomer_ID")
                .IsRequired(false);
            
            builder.Property(x => x.AcceptedTerms)
                .HasColumnName("AcceptedTerms")
                .IsRequired();
            
            builder.Property(x => x.LanguageId)
                .HasColumnName("Language_ID")
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnName("Status")
                .IsRequired();
            
            builder.Property(x => x.IsDeleted)
                .HasColumnName("IsDeleted");

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();

            Relationships(builder);
            Constrains(builder);
        }

        private void Relationships(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(x => x.Language)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.LanguageId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void Constrains(EntityTypeBuilder<User> builder)
        {
            builder.HasQueryFilter(p => p.Status);
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
