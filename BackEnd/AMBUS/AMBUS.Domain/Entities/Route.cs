namespace AMBUS.Domain.Entities
{
    public class Route
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
