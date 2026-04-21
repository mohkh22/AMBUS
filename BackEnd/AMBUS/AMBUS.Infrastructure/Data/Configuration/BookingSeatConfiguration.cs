using AMBUS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMBUS.Infrastructure.Data.Configuration
{
    public class BookingSeatConfiguration : IEntityTypeConfiguration<BookingSeat>
    {
        public void Configure(EntityTypeBuilder<BookingSeat> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Trip)
                .WithMany()
                .HasForeignKey(x => x.TripId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Seat)
                .WithMany()
                .HasForeignKey(x => x.SeatId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Book)
                .WithMany(x=>x.Seats)
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Property(x => x.IsDeleted)
               .HasDefaultValue(false);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(x => x.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
