namespace AMBUS.Domain.Entities
{
    public class Bus
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!; 
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
