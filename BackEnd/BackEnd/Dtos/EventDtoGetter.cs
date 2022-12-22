namespace BackEnd.Dtos
{
    public class EventDtoGetter
    {
        public int? IdEvent { get; set; }

        public string? EventName { get; set; }

        public int? IdVenue { get; set; }

        public string? Description { get; set; }

        public int? IdBusinessAccount { get; set; }

        public string? startHour { get; set; }

        public string? endHour { get; set; }

        public string? startDate { get; set; }

        public string? endDate { get; set; }

        public int? IdCategory { get; set; }
    }
}
