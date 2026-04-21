using AMBUS.Domain.Enum;

namespace AMBUS.Domain.Entities
{
    public class Trip
    {
        public int Id { get; set; }
        public int FromRouteId { get; set; }
        public Route? From { get; set; }

        public int ToRouteId { get; set; }
        public Route? To { get; set; }

        public int BusId { get; set; }
        public Bus? Bus { get; set; }

        public int DriverId { get; set; }
        public Driver? Driver { get; set; }

        public DateTime TripTime {  get; set; }
        public DateTime ArrivalTime { get; set; }
        public BookStatus Status { get; set; } 
        public decimal Price { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}
