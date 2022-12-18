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
        public async Task<Venue> EditVenue(Venue venue)
        {
            var result = await CheckIfVenueExists(venue.IdVenue);
            result.Address = venue.Address;
            result.Description = venue.Description;
            result.ContactNumber = venue.ContactNumber;
            result.Name = venue.Name;

            _context.Venues.Update(result);
            await (_context.SaveChangesAsync());
            return result;
        }

        public async Task<Venue> CheckIfVenueExists(int? id)
        {
            var venue = await _context.Venues.FirstOrDefaultAsync(v => v.IdVenue == id);
            if (venue == null)
            {
                return null;
            }
            else
            {

                return venue;
            }
        }
    }
}
