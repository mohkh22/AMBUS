using AMBUS.Domain.Entities;
using AMBUS.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMBUS.Infrastructure.Data.Configuration
{
    public class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasKey(x => x.Id); 

            builder.HasOne(x=>x.From)
                .WithMany()
                .HasForeignKey(x => x.FromRouteId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.To)
               .WithMany()
               .HasForeignKey(x => x.ToRouteId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Bus)
              .WithMany()
              .HasForeignKey(x => x.BusId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Driver)
              .WithMany()
              .HasForeignKey(x => x.DriverId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.TripTime)
                .IsRequired();

            builder.Property(x => x.ArrivalTime)
               .IsRequired();

            builder.Property(x => x.Status)
               .HasDefaultValue(BookStatus.Pending);

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            builder.Property(x => x.IsDeleted)
          .HasDefaultValue(false);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(x => x.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
