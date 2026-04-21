using AMBUS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMBUS.Infrastructure.Data.Configuration
{
    public class BusConfiguration : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Number)
                .IsRequired().HasMaxLength(100);

            builder.Property(x=>x.Capacity)
                .IsRequired().HasDefaultValue(50);

            builder.Property(x => x.IsAvailable)
                .HasDefaultValue(true); 

            builder.Property(x => x.IsDeleted)
              .HasDefaultValue(false);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(x => x.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
