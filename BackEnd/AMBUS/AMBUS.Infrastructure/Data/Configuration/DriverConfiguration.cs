using AMBUS.Domain.Entities;
using AMBUS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMBUS.Infrastructure.Data.Configuration
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.HasKey(x => x.Id); 
            builder.HasOne<AppUser>()
                .WithMany()
                .HasForeignKey(x=>x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.NationalNumber)
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(x => x.DrivingLicense)
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(x => x.LicenseExpire)
                .IsRequired();           

            builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(x => x.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
