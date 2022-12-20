namespace BackEnd.Dtos
{
    public class BusinessAccountEditRequest
    {
        public int? IdBusinessAccount { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Email { get; set; }

        public string? ContactNumber { get; set; }

        public int? IdVenue { get; set; }
    }
}
