using Asp.Omeno.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Asp.Omeno.Service.Persistence.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
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

            builder.Property(x => x.ZipCode)
              .HasColumnName("ZipCode")
              .IsRequired();

            builder.Property(x => x.CountryId)
             .HasColumnName("Country_ID")
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

            builder.ToTable("Cities");
        }

        private void Relationships(EntityTypeBuilder<City> builder)
        {
            builder.HasOne(x => x.Country)
                .WithMany(x => x.Cities)
                .HasForeignKey(x => x.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void Constrains(EntityTypeBuilder<City> builder)
        {
            builder.HasQueryFilter(p => p.Status);
        }
    }
}
