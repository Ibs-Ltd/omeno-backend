using Asp.Omeno.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asp.Omeno.Service.Persistence.Configurations
{
    public class NotificationUserConfiguration : IEntityTypeConfiguration<NotificationUser>
    {
        public void Configure(EntityTypeBuilder<NotificationUser> builder)
        {
            builder.HasKey(x => new { x.NotificationId, x.UserId});

            builder.Property(x => x.Id)
               .HasColumnName("ID")
               .IsRequired();

            builder.Property(x => x.NotificationId)
               .HasColumnName("Notification_ID")
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

            builder.ToTable("NotificationUsers");
        }

        private void Relationships(EntityTypeBuilder<NotificationUser> builder)
        {
            builder.HasOne(x => x.Notification)
                .WithMany(x => x.NotificationUsers)
                .HasForeignKey(x => x.NotificationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.User)
                .WithMany(x => x.NotificationUsers)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void Constrains(EntityTypeBuilder<NotificationUser> builder)
        {
            builder.HasQueryFilter(p => p.Status);
        }
    }
}
