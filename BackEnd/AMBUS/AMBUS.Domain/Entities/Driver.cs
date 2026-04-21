namespace AMBUS.Domain.Entities
{
    public class Driver
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public string NationalNumber { get; set; } = null!; 
        public string DrivingLicense { get; set; } = null!; 
        public DateTime LicenseExpire { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
