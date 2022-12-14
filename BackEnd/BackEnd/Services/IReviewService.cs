using BackEnd.Models;

namespace BackEnd.Services
{
    public interface IReviewService
    {
        public Task<bool> AddReviewToDatabase(Review myReview);

        //public Task<List<Event>> GetAllReviewsByUser(int idUser);

        //public Task<Review> GetReviewById(int IdReview);

    }
}