using Asp.Omeno.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asp.Omeno.Service.Persistence.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
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

            builder.Property(x => x.VAT)
               .HasColumnName("VAT")
               .IsRequired();

            builder.Property(x => x.CurrencyId)
               .HasColumnName("Currency_ID")
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

            builder.ToTable("Countries");
        }

        private void Relationships(EntityTypeBuilder<Country> builder)
        {
            builder.HasOne(x => x.Currency)
                .WithMany(x => x.Countries)
                .HasForeignKey(x => x.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void Constrains(EntityTypeBuilder<Country> builder)
        {
            builder.HasQueryFilter(p => p.Status);
        }
    }
}
