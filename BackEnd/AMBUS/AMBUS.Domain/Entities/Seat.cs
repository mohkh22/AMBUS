namespace AMBUS.Domain.Entities
{
    public class Seat
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int BusId { get; set; }
        public Bus? Bus { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
