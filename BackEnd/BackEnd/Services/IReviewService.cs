using BackEnd.Models;

namespace BackEnd.Services
{
    public interface IReviewService
    {
        public Task<bool> AddReviewToDatabase(Review myReview);
        public Task<Review> GetReviewById(int IdReview);
        public Task<Review> GetLastReview();
        public Task<List<Review>> GetAllReviewsByUser(int idUser);
        public Task<bool> DeleteReview(Review r);
        public Task<Review> CheckIfReviewExists(int? id);
    }
}