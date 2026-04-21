using AMBUS.Domain.Enum;

namespace AMBUS.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public string SessionId { get; set; } = null!; 
        public BookStatus Status { get; set; } 

        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
