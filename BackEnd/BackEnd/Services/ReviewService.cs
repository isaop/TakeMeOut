using BackEnd.Database;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Services
{
    public class ReviewService : IReviewService
    {
        private readonly TakeMeOutDbContext _context;

        public ReviewService(TakeMeOutDbContext context)
        {
            _context = context;

        }
        public async Task<bool> AddReviewToDatabase(Review myReview)
        {
            myReview.IdReview = null;

            _context.Reviews.Add(myReview);

            await (_context.SaveChangesAsync());
            return true;
        }

       
        public async Task<Review> GetLastReview()
        {
            var review = _context.Reviews.OrderByDescending(q => q.IdEvent).FirstOrDefaultAsync();
            return await review;
        }
    }
}
