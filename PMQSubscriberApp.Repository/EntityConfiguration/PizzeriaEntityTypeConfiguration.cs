using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMQSubscriberApp.Entities.Models;

namespace PMQSubscriberApp.Repository.EntityConfiguration
{
    public class PizzeriaEntityTypeConfiguration : IEntityTypeConfiguration<Pizzeria>
    {
        public void Configure(EntityTypeBuilder<Pizzeria> builder)
        {
            builder.Property(p => p.PizzeriaName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.AddressLine1)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.AddressLine2)
                .HasMaxLength(100);
            builder.Property(p => p.City)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(p => p.State)
                .IsRequired()
                .HasMaxLength(25);
            builder.Property(p => p.ZipCode)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(p => p.Phone)
                .HasMaxLength(25);
            builder.Property(p => p.NumberOfLocations)
                .HasDefaultValue(0);
            builder.HasIndex(p => p.PizzeriaName);
            builder.HasIndex(p => p.State);
            builder.HasIndex(p => p.ZipCode);
            builder.HasMany(p => p.Contacts)
                .WithMany(c => c.Pizzerias)
                .UsingEntity(j => j.ToTable("PizzeriaContact"));
        }
    }
}
