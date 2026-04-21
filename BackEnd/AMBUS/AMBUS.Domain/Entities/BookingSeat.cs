namespace AMBUS.Domain.Entities
{
    public class BookingSeat
    {
        public int Id { get; set; }
        public int TripId { get; set; }
        public Trip? Trip { get; set; }
        public int SeatId { get; set; }
        public Seat? Seat { get; set; }

        public int BookId { get; set; }
        public Book? Book { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
