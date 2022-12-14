using BackEnd.Database;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Services
{
    public class VenueService : IVenueService
    {
        private readonly TakeMeOutDbContext _context;

        public VenueService(TakeMeOutDbContext context)
        {
            _context = context;
        }

        public async Task<Venue> GetVenueByID(int id)
        {
            return await _context.Venues.Where(v => v.IdVenue == id).FirstOrDefaultAsync();
        }

        public async Task<List<Venue>> GetAllVenues()
        {
            return await _context.Venues.ToListAsync();
        }
    }
}
