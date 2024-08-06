namespace DynamicMapping.Core
{
    public class MappingModelBase
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public Reservation Reservation { get; set;}
    }

    public class Reservation
    {
        public int RoomNumber { get; set; }
        public int GuestQuantity { get; set; }
    }
}
