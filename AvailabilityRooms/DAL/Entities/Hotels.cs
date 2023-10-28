namespace AvailabilityRooms.DAL.Entities
{
    public class Hotels : AuditBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Stars { get; set; }
        public string City { get; set; }


        public List<Rooms>? Rooms { get; set; }
    }
}
