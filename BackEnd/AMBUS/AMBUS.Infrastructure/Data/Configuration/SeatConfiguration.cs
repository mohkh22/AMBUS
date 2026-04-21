using AMBUS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMBUS.Infrastructure.Data.Configuration
{
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(x => x.Number)
                .IsRequired(); 

            builder.HasOne(x=>x.Bus)
                .WithMany()
                .HasForeignKey(x => x.BusId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Property(x => x.IsDeleted)
           .HasDefaultValue(false);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(x => x.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
