namespace AMBUS.Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }

        public int BookingSeatId { get; set; }
        public BookingSeat? BookingSeat { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
