namespace AvailabilityRooms.DAL.Entities
{
    public class Rooms : AuditBase
    {

        public Guid Id { get; set; }
        public int Number { get; set; }
        public int MaxGuests { get; set; }
        public bool Availability { get; set; }

        public Guid HotelId { get; set; } // Clave foránea para relacionar con Hotel
        public Hotels hotels { get; set; }
    }
}
