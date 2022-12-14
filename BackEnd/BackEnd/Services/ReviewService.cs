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

        

        public async Task<List<Event>> GetAllEventsByName(string eventName)
        {
            return await _context.Events.Where(e => e.EventName == eventName).ToListAsync();
        }

        public async Task<Event> GetEventById(int id)
        {
            return await _context.Events.Where(e => e.IdEvent == id).FirstOrDefaultAsync();
        }

        public async Task<Event> GetLastEvent()
        {
            var eventt = _context.Events.OrderByDescending(q => q.IdEvent).FirstOrDefaultAsync();
            return await eventt;
        }
    }
}
