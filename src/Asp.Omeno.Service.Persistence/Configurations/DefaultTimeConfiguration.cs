using Asp.Omeno.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asp.Omeno.Service.Persistence.Configurations
{
    public class DefaultTimeConfiguration : IEntityTypeConfiguration<DefaultTime>
    {
        public void Configure(EntityTypeBuilder<DefaultTime> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("ID")
               .IsRequired();

            builder.Property(x => x.StartTime)
               .HasColumnName("StartTime")
               .IsRequired();

            builder.Property(x => x.EndTime)
               .HasColumnName("EndTime")
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

            builder.ToTable("DefaultTimes");
        }

        private void Constrains(EntityTypeBuilder<DefaultTime> builder)
        {
            builder.HasQueryFilter(p => p.Status);
        }
    }
}
