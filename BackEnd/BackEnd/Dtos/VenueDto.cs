namespace BackEnd.Dtos
{
    public class VenueDto
    {

        public VenueDto(string? name, string? address, string? contactNo, string? description) 
        {
            Name = name;
            Address = address;
            ContactNumber = contactNo;
            Description = description;
        }

        public int? IdVenue { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? ContactNumber { get; set; }

        public string? Description { get; set; }
    }
}
