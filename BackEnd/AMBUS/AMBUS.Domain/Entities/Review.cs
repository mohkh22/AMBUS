namespace AMBUS.Domain.Entities
{
    public  class Review
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public int TripId { get; set; }
        public Trip? Trip {  get; set; }

        public int Rating { get; set; }
        public string? Comment { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}
