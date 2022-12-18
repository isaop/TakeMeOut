namespace BackEnd.Dtos
{
    public class ReviewDto
    {
        public int? IdReview { get; set; }

        public int? IdEvent { get; set; }

        public int? IdUser { get; set; }

        public int? IdPayment { get; set; }

        public string? Comment { get; set; }
    }
}
