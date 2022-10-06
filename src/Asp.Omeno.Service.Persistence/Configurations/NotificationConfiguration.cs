using Asp.Omeno.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Asp.Omeno.Service.Persistence.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("ID")
               .IsRequired();

            builder.Property(x => x.Title)
               .HasColumnName("Title")
               .IsRequired();

            builder.Property(x => x.Message)
               .HasColumnName("Message")
               .IsRequired();

            builder.Property(x => x.AutoNotify)
               .HasColumnName("AutoNotify")
               .IsRequired();

            builder.Property(x => x.Active)
               .HasColumnName("Active")
               .IsRequired();

            builder.Property(x => x.Timer)
               .HasColumnName("Timer")
               .IsRequired();

            builder.Property(x => x.TimeToNotify)
               .HasColumnName("TimeToNotify")
               .IsRequired();

            builder.Property(x => x.NotificationTypeId)
               .HasColumnName("NotificationType_ID")
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

            builder.ToTable("Notifications");
        }

        private void Relationships(EntityTypeBuilder<Notification> builder)
        {
            builder.HasOne(x => x.NotificationType)
                .WithMany(x => x.Notifications)
                .HasForeignKey(x => x.NotificationTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void Constrains(EntityTypeBuilder<Notification> builder)
        {
            builder.HasQueryFilter(p => p.Status);
        }
    }
}
