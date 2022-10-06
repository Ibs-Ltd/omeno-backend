using Asp.Omeno.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asp.Omeno.Service.Persistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("ID")
               .IsRequired();

            builder.Property(x => x.AddressName)
               .HasColumnName("AddressName")
               .IsRequired();

            builder.Property(x => x.AddressNameTwo)
               .HasColumnName("AddressNameTwo")
               .IsRequired(false);

            builder.Property(x => x.CityName)
               .HasColumnName("CityName")
               .IsRequired(false);

            builder.Property(x => x.CountryName)
               .HasColumnName("CountryName")
               .IsRequired(false);

            builder.Property(x => x.PostalCode)
               .HasColumnName("PostalCode")
               .IsRequired(false);

            builder.Property(x => x.UserId)
               .HasColumnName("User_ID")
               .IsRequired();

            builder.Property(x => x.AddressTypeId)
               .HasColumnName("AddressType_ID")
               .IsRequired();

            builder.Property(x => x.CityId)
               .HasColumnName("City_ID")
               .IsRequired(false);

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

            builder.ToTable("Addresses");
        }

        private void Relationships(EntityTypeBuilder<Address> builder)
        {
            builder.HasOne(x => x.City)
                .WithMany(x => x.Addresses)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.AddressType)
                .WithMany(x => x.Addresses)
                .HasForeignKey(x => x.AddressTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Addresses)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void Constrains(EntityTypeBuilder<Address> builder)
        {
            builder.HasQueryFilter(p => p.Status);
        }
    }
}
