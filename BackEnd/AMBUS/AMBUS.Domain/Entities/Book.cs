using AMBUS.Domain.Enum;

namespace AMBUS.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string UserId { get; set; } = null!;
        public BookStatus Status { get; set; }
        public decimal TotalPrice { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<BookingSeat> Seats { get; set; } = new List<BookingSeat>();
    }
}
