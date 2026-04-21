using AMBUS.Domain.Entities;
using AMBUS.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AMBUS.Infrastructure.Data
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
       
        public DbSet<Book> Books { get; set; }
        public DbSet<BookingSeat> BookingSeats { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Police> Polices { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // register All Configuration 
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            // Execute Query when get From DB
            builder.Entity<Book>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Bus>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Chat>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Driver>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Notification>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Payment>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Police>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Review>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Route>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Seat>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Ticket>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Trip>().HasQueryFilter(x => !x.IsDeleted);

            builder.Entity<BookingSeat>().HasQueryFilter(x => !x.IsDeleted)
                        .HasIndex(x => new { x.SeatId, x.TripId })
                        .IsUnique();

            base.OnModelCreating(builder);
        }


    }
}
