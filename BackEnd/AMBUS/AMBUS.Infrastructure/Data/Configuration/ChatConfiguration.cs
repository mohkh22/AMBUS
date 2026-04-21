using AMBUS.Domain.Entities;
using AMBUS.Infrastructure.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMBUS.Infrastructure.Data.Configuration
{
    public class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne<AppUser>()
                .WithMany()
                .HasForeignKey(x => x.ReceiveId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<AppUser>()
               .WithMany()
               .HasForeignKey(x => x.SendId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Message)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.IsRead)
                .HasDefaultValue(false); 

            builder.Property(x => x.IsDeleted)
             .HasDefaultValue(false);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(x => x.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
