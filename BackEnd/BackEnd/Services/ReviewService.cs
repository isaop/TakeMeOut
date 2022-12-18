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

        public async Task<Review> GetReviewById(int idReview)
        {
            return await _context.Reviews.Where(r => r.IdReview == idReview).FirstOrDefaultAsync();
        }

        public async Task<List<Review>> GetAllReviewsByUser(int idUser)
        {
            return await _context.Reviews.Where(r => r.IdUser == idUser).ToListAsync();
        }
    }
}
