using Asp.Omeno.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asp.Omeno.Service.Persistence.Configurations
{
    public class EmailTemplateConfiguration : IEntityTypeConfiguration<EmailTemplate>
    {
        public void Configure(EntityTypeBuilder<EmailTemplate> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("ID")
               .IsRequired();

            builder.Property(x => x.Title)
               .HasColumnName("Title")
               .IsRequired();

            builder.Property(x => x.Content)
               .HasColumnName("Content")
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

            builder.ToTable("EmailTemplates");
        }

        private void Constrains(EntityTypeBuilder<EmailTemplate> builder)
        {
            builder.HasQueryFilter(p => p.Status);
        }
    }
}
