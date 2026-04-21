using AMBUS.Domain.Entities;
using AMBUS.Infrastructure.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMBUS.Infrastructure.Data.Configuration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne<AppUser>()
                .WithMany()
                .HasForeignKey(x=>x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x=>x.Trip)
                .WithMany()
                .HasForeignKey(x=>x.TripId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Rating)
                .HasDefaultValue(0)
                .HasMaxLength(5);

            builder.Property(x => x.Comment)
                .HasMaxLength(200); 


            builder.Property(x => x.IsDeleted)
             .HasDefaultValue(false);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(x => x.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
