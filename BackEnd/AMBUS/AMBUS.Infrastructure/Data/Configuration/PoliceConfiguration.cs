using AMBUS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMBUS.Infrastructure.Data.Configuration
{
    public class PoliceConfiguration : IEntityTypeConfiguration<Police>
    {
        public void Configure(EntityTypeBuilder<Police> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired().HasMaxLength(100);

            builder.Property(x => x.Description)
                .HasMaxLength(500); 

            builder.Property(x => x.IsDeleted)
              .HasDefaultValue(false);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(x => x.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
