namespace AMBUS.Domain.Entities
{
    public  class Chat
    {
        public int Id { get; set; }
        public string SendId { get; set; } = null!; 
        public string ReceiveId { get; set; } = null!; 
        public string Message { get; set; } = null!;
        public bool IsRead { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
