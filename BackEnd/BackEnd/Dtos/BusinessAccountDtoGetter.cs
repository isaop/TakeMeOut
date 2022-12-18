namespace BackEnd.Dtos
{
    public class BusinessAccountDtoGetter
    {
        public BusinessAccountDtoGetter(string name, string description, int idVenue,
            string email, string contactNo, string venueName, string venueDescription) 
        {
            Name = name;
            Description = description;
            IDVenue = idVenue;
            Email = email;
            ContactNumber = contactNo;
            VenueName = venueName;
            VenueDescription = venueDescription;
        }
        public string Name { get; }
        public string Description { get; }
        public int IDVenue { get; }
        public string Email { get; }
        public string ContactNumber { get; }
        public string VenueName { get; }
        public string VenueDescription { get; }
    }
}
