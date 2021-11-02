using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMQSubscriberApp.Entities.Models;

namespace PMQSubscriberApp.Repository.EntityConfiguration
{
    public class ContactEntityTypeConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.JobTitle)
                .HasMaxLength(50);
            builder.HasIndex(c => c.LastName);
        }
    }
}
